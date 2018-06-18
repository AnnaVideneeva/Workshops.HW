using AngleSharp.Dom.Html;
using PCRE;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.UoW;
using Rocket.Parser.Exceptions;
using Rocket.Parser.Interfaces;
using Rocket.Parser.Models;
using Rocket.Parser.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Const = Rocket.Parser.Heplers.CommonHelper;
using Helper = Rocket.Parser.Heplers.AlbumInfoHelper;

namespace Rocket.Parser.Parsers
{
    internal class AlbumInfoParser : IAlbumInfoParser
    {
        private readonly ILoadHtmlService _loadHtmlService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="loadHtmlService">Сервис загрузки HTML</param>
        /// <param name="unitOfWork">UoW</param>
        public AlbumInfoParser(ILoadHtmlService loadHtmlService, IUnitOfWork unitOfWork)
        {
            _loadHtmlService = loadHtmlService;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        /// <summary>
        /// Запуск парсинга сайта album-info.ru 
        /// </summary>
        public async Task ParseAsync()
        {
            try
            {
                // получаем настройки парсера
                var resource = _unitOfWork.ResourceRepository
                    .Queryable().First(r => r.Name.Equals(Resources.AlbumInfoSettings));

                var settings = _unitOfWork.ParserSettingsRepository.Queryable().
                    Where(ps => ps.ResourceId == resource.Id)
                    .ToList();

                // по каждой настройке выполняем парсинг
                foreach (var setting in settings)
                {
                    var resourceItemsBc = new BlockingCollection<ResourceItemEntity>();
                    var releasesBc = new BlockingCollection<AlbumInfoRelease>();

                    var taskList = new List<Task>();

                    for (var index = setting.StartPoint; index <= setting.EndPoint; index++)
                    {
                        var task = ParseAlbumInfo(setting, resource.ResourceLink, index, resourceItemsBc, releasesBc);

                        taskList.Add(task);
                    }

                    await Task.WhenAll(taskList.ToArray());

                    //фиксация данных в БД
                    SaveResults(resourceItemsBc, releasesBc);
                }
            }
            catch (Exception excpt)
            {
                throw excpt;
            }
        }

        /// <summary>
        /// Парсинг сайта
        /// </summary>
        /// <param name="setting">Настройки парсера</param>
        /// <param name="resourceLink">Ссылка на ресурс</param>
        /// <param name="index">Текущая страница со списком релизов</param>
        /// <param name="resourceItemsBc">Потокобезопасная коллекция элементов ресурса</param>
        /// <param name="releasesBc">Потокобезопасная коллекция релизов сайта</param>
        /// <returns>Task</returns>
        private async Task ParseAlbumInfo(
            ParserSettingsEntity setting, string resourceLink, int index, 
            BlockingCollection<ResourceItemEntity> resourceItemsBc, BlockingCollection<AlbumInfoRelease> releasesBc)
        {
            var linksPageUrl = $"{setting.BaseUrl}{setting.Prefix}{index}";

            //загружаем страницу со ссылками на релизы
            var linksPageHtmlDoc = await _loadHtmlService.GetHtmlDocumentByUrlAsync(linksPageUrl).
                ConfigureAwait(false);

            //получаем ссылки на страницы релизов
            var releaseLinkList = ParseAlbumlist(linksPageHtmlDoc);

            await Task.WhenAll(releaseLinkList.Select(releaseLink => ParseReleasInfo(setting, resourceLink,
                releaseLink, resourceItemsBc, releasesBc)).ToArray()).ConfigureAwait(false);
        }

        /// <summary>
        /// Парсинг релиза
        /// </summary>
        /// <param name="setting">Настройки парсера</param>
        /// <param name="resourceLink">Ссылка на ресурс</param>
        /// <param name="releaseLink">Ссылка на релиз</param>
        /// <param name="resourceItemsBc">Потокобезопасная коллекция элементов ресурса</param>
        /// <param name="releasesBc">Потокобезопасная коллекция релизов сайта</param>
        /// <returns>Task</returns>
        private async Task ParseReleasInfo(ParserSettingsEntity setting, string resourceLink, string releaseLink, 
            BlockingCollection<ResourceItemEntity> resourceItemsBc, BlockingCollection<AlbumInfoRelease> releasesBc)
        {
            var releaseUrl = resourceLink + releaseLink;
            var resourceInternalId = releaseLink.Replace(Resources.AlbumInfoInternalPrefixId, "");

            resourceItemsBc.Add(new ResourceItemEntity
            {
                ResourceId = setting.ResourceId,
                ResourceInternalId = resourceInternalId,
                ResourceItemLink = releaseLink
            });

            //парсим страницу релиза
            var releaseHtmlDoc = await _loadHtmlService.GetHtmlDocumentByUrlAsync(releaseUrl).ConfigureAwait(false);
            var release = ParseRelease(releaseHtmlDoc);

            if (release != null)
            {
                release.ResourceInternalId = resourceInternalId;
                
                //загружаем обложку релиза
                await LoadAndSaveReleaseCover(release, resourceLink, setting.ResourceId).ConfigureAwait(false);

                releasesBc.Add(release);
            }
        }

        /// <summary>
        /// Сохраняет в БД результаты парсинга
        /// </summary>
        /// <param name="resourceItemsBc">resourceItemsBc</param>
        /// <param name="releasesBc">releasesBc</param>
        private void SaveResults(BlockingCollection<ResourceItemEntity> resourceItemsBc,
            BlockingCollection<AlbumInfoRelease> releasesBc)
        {
            if (!resourceItemsBc.Any() && !releasesBc.Any())
                throw new AlbumInfoReleaseException(Helper.EmptyReleaseException);

            var resourceItems = resourceItemsBc.ToList();

            foreach (var resourceItem in resourceItems)
            {
                //находим соответствующий релиз
                var release = releasesBc.FirstOrDefault(r => r.ResourceInternalId == resourceItem.ResourceInternalId);

                if (release != null)
                {
                    var music = MapAlbumInfoReleaseToMusic(release);
                    var musicId = SaveRelease(music);
                    resourceItem.MusicId = musicId;

                    SaveMusicTrack(release.TrackList, musicId);

                    SaveResourceItem(resourceItem);
                }
                else
                {
                    throw new AlbumInfoReleaseException(
                        string.Format(Helper.ParsReleaseException, resourceItem.ResourceInternalId));
                }
            }
        }

        /// <summary>
        /// Сохраняет релиз
        /// </summary>
        /// <param name="music">Музыкальный релиз</param>
        /// <returns>Id сущности музыка</returns>
        private int SaveRelease(DbMusic music)
        {
            //проверяем существует ли релиз
            var musicEntity = _unitOfWork.MusicRepository.Queryable().
                Include(a => a.Genres).
                Include(m => m.Musicians).
                FirstOrDefault(mr => mr.Title.Equals(music.Title) && mr.Artist.Equals(music.Artist));

            if (musicEntity != null)
            {
                //обновляем релиз
                musicEntity.Genres = music.Genres;
                musicEntity.Musicians = music.Musicians;
                musicEntity.ReleaseDate = music.ReleaseDate;
                musicEntity.Duration = music.Duration;
                musicEntity.Type = music.Type;
                musicEntity.PosterImagePath = music.PosterImagePath;

                _unitOfWork.MusicRepository.Update(musicEntity);
                _unitOfWork.SaveChanges();

                return musicEntity.Id;
            }

            //создаем новый релиз
            _unitOfWork.MusicRepository.Insert(music);
            _unitOfWork.SaveChanges();

            return music.Id;
        }

        /// <summary>
        /// Сохранение элемента ресурса
        /// </summary>
        /// <param name="resourceItem">Элемент ресурса</param>
        private void SaveResourceItem(ResourceItemEntity resourceItem)
        {
            //обрабатываем элемент ресурса
            var resourceItemEntity = _unitOfWork.ResourceItemRepository.Queryable().FirstOrDefault(ri =>
                ri.ResourceId == resourceItem.ResourceId &&
                ri.ResourceInternalId == resourceItem.ResourceInternalId);

            if (resourceItemEntity != null)
            { // обновляем информацию о релизе
                resourceItemEntity.ResourceItemLink = resourceItem.ResourceItemLink;
                resourceItemEntity.MusicId = resourceItem.MusicId;

                _unitOfWork.ResourceItemRepository.Update(resourceItemEntity);
                _unitOfWork.SaveChanges();
                resourceItem.Id = resourceItemEntity.Id;
            }
            else
            { // сохраняем информацию о релизе
                _unitOfWork.ResourceItemRepository.Insert(resourceItem);
                _unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Мапирует релиз сайта album-info в музыкальный релиз
        /// </summary>
        /// <param name="release">Релиз сайта album-info</param>
        /// <returns>Музыкальный релиз</returns>
        private DbMusic MapAlbumInfoReleaseToMusic(AlbumInfoRelease release)
        {
            var music = new DbMusic();

            var releaseName = PcreRegex.Match(release.Name, Helper.ReleaseNamePattern).Value;
            var releaseType = PcreRegex.Matches(release.Name, Helper.ReleaseTypePattern)
                .Select(m => m.Value).LastOrDefault();
            var releaseArtist = release.Name.Substring(0, release.Name.IndexOf(" - ", StringComparison.Ordinal));
            var releaseGenres = PcreRegex.Matches(release.Genre, Helper.ReleaseGenrePattern).Select(m => m.Value);
            var dateFormat = release.Date.Length > 4 ? Helper.LongDateFormat : Helper.ShortDateFormat;
            var provider = CultureInfo.CreateSpecificCulture(Const.CultureInfoText);
            var releaseDate = DateTime.ParseExact(release.Date, dateFormat, provider);

            SaveMusician(music, releaseArtist);
            SaveGenre(music, releaseGenres);

            music.Title = string.IsNullOrEmpty(releaseName) ? Helper.UnknownName : releaseName;
            music.ReleaseDate = releaseDate;
            music.Type = releaseType;
            music.Artist = string.IsNullOrEmpty(releaseArtist) ? Helper.UnknownArtist : releaseArtist;
            music.PosterImagePath = release.CoverPath;
            music.PosterImageUrl = release.ImageFullUrl;

            return music;
        }

        /// <summary>
        /// Сохранение жанров релиза
        /// </summary>
        /// <param name="music">Музыкальный релиз</param>
        /// <param name="releaseGenres">Список жанров релиза</param>
        private void SaveGenre(DbMusic music, IEnumerable<string> releaseGenres)
        {
            foreach (var releaseGenre in releaseGenres)
            {
                //проверяем существует ли жанр
                var genreEntity = _unitOfWork.MusicGenreRepository.Queryable().FirstOrDefault(g => g.Name.Equals(releaseGenre));
                if (genreEntity != null)
                {
                    music.Genres.Add(genreEntity);
                }
                else
                {
                    var newMusicGenres = new DbMusicGenre
                    {
                        Name = releaseGenre
                    };

                    _unitOfWork.MusicGenreRepository.Insert(newMusicGenres);
                    _unitOfWork.SaveChanges();

                    music.Genres.Add(newMusicGenres);
                }
            }
        }

        /// <summary>
        /// Сохранение исполнителя релиза
        /// </summary>
        /// <param name="music">Музыкальный релиз</param>
        /// <param name="releaseArtist">Исполнитель релиза</param>
        private void SaveMusician(DbMusic music, string releaseArtist)
        {
            //проверяем существует ли исполнитель
            var musicianEntity = _unitOfWork.MusicianRepository.Queryable().
                FirstOrDefault(m => m.FullName.Equals(releaseArtist));
            if (musicianEntity != null)
            {
                music.Musicians.Add(musicianEntity);
            }
            else
            {
                var newMusician = new DbMusician
                {
                    FullName = releaseArtist
                };

                _unitOfWork.MusicianRepository.Insert(newMusician);
                _unitOfWork.SaveChanges();

                music.Musicians.Add(newMusician);
            }
        }

        /// <summary>
        /// Сохранение музыкальных треков
        /// </summary>
        /// <param name="trakList">Список треков одного релиза</param>
        /// <param name="musicId">ID релиза</param>
        private void SaveMusicTrack(string trakList, int musicId)
        {
            var trackListRelease = PcreRegex.Matches(trakList, Helper.ReleaseTrackListPattern)
                .Select(m => m.Value).ToList();

            //обрабатываем треклист
            foreach (var track in trackListRelease)
            {
                var trackEntity = _unitOfWork.MusicTrackRepository.Queryable().
                    FirstOrDefault(t => t.Title.Equals(track) && t.DbMusicId == musicId);
                if (trackEntity == null)
                {
                    _unitOfWork.MusicTrackRepository.Insert(new DbMusicTrack
                    {
                        Title = track,
                        DbMusicId = musicId
                    });
                }
            }

            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Парсинг страницы содержащей ссылки на релизы
        /// </summary>
        /// <param name="document">IHtmlDocument</param>
        /// <returns>Массив ссылок на страницы релизов</returns>
        private string[] ParseAlbumlist(IHtmlDocument document)
        {
            var list = new List<string>();

            // парсинг таблицы содержащей релизы(столбцы таблицы)
            for (var i = 1; i < 4; i++) 
            {
                // строки таблицы
                for (var j = 1; j < 5; j++) 
                {
                    var item = document.QuerySelector(
                        string.Format(Resources.AlbumInfoReleaseLinkSelector, i, j));

                    if (item != null)
                    {
                        list.Add(item.GetAttribute(Const.HrefAttribute));
                    }
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Парсинг страницы релиза
        /// </summary>
        /// <param name="document">HTML-страница релиза</param>
        /// <returns>Модель релиза на сайте album-info.ru</returns>
        private AlbumInfoRelease ParseRelease(IHtmlDocument document)
        {
            var release = new AlbumInfoRelease
            {
                Name = document.QuerySelector(Resources.AlbumInfoReleaseNameSelector).TextContent,
                Date = document.QuerySelector(Resources.AlbumInfoReleaseDateSelector).TextContent,
                ImageUrl = document.QuerySelector(Resources.AlbumInfoReleaseImageUrlSelector)
                    .GetAttribute(Const.HrefAttribute),
                Genre = document.QuerySelector(Resources.AlbumInfoReleaseGenreSelector).TextContent,
                TrackList = document.QuerySelector(Resources.AlbumInfoReleaseTrackListSelector).TextContent
            };

            return release;
        }

        /// <summary>
        /// Загружает и сохраняет в файловую систему обложку релиза
        /// </summary>
        /// <param name="release">Релиз</param>
        /// <param name="resourceLink">Адрес сайта</param>
        /// <param name="resourceId">ID ресурса</param>
        /// <returns>Task</returns>
        private async Task LoadAndSaveReleaseCover(AlbumInfoRelease release, string resourceLink, int resourceId)
        {
            var url = resourceLink + release.ImageUrl;
            var folderPath = $"{Helper.CoversPath}{resourceId}{@"\"}{DateTime.Now:yyyy_MM}{@"\"}";
            var fileName = $"{release.ResourceInternalId}{Path.GetExtension(release.ImageUrl)}";
            var fillPath = folderPath + fileName;
            var exists = Directory.Exists(folderPath);
            if (!exists) Directory.CreateDirectory(folderPath);
            if (File.Exists(fillPath))
            {
                File.Delete(fillPath);
            }

            await _loadHtmlService.DownloadFile(url, fillPath).ConfigureAwait(false);

            release.CoverPath = fillPath;
            release.ImageFullUrl = url;
        }
    }
}

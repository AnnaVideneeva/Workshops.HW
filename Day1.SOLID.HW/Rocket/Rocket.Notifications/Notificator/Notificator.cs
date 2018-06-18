using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Rocket.BL.Common.Services.Notification;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.UoW;
using Rocket.Notifications.Interfaces;
using System.Net.Http;
using System.Text;
using Rocket.DAL.Common.DbModels.Notification;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.DbModels.Subscription;
using Rocket.Notifications.Properties;
using Rocket.Web.Models;

namespace Rocket.Notifications.Notificator
{
    /// <inheritdoc />
    /// <summary>
    /// Инициация отправки уведомлений
    /// </summary>
    public class Notificator : IPushNotificator
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailNotificationService _mailNotificationService;
        private readonly HttpClient _httpClient;


        public Notificator(IUnitOfWork unitOfWork, IMailNotificationService mailNotificationService,
            HttpClient httpClient)
        {
            _unitOfWork = unitOfWork;
            _mailNotificationService = mailNotificationService;
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        /// <summary>
        /// Отправка уведомлений
        /// </summary>
        /// <returns></returns>
        public async Task NotifyAsync()
        {
            var settings = _unitOfWork.NotificationSettingsRepository
                .Queryable().First(r => r.Name.Equals(Resources.NotificationsSettings));


            await NotifyOfMusicReleases(settings);
            await NotifyOfTvSeriesReleases(settings);
        }

        /// <summary>
        /// Обработка музыкальных релизов
        /// </summary>
        /// <param name="settings">Настройки сервиса</param>
        /// <returns></returns>
        private async Task NotifyOfMusicReleases(NotificationsSettingsEntity settings)
        {
            try
            {
                var currDateTime = DateTime.Now;

                var musicReleases = GetMusicReleases(currDateTime);

                var taskList = new List<Task> { _mailNotificationService.NotifyAboutReleaseAsync(musicReleases) };

                var pushNotifications = CastMusicToPushModel(musicReleases);
                if (pushNotifications.Any())
                {
                    taskList.Add(SendPushNotifications(settings, pushNotifications));
                }

                await Task.WhenAll(taskList.ToList());
                SaveNotificationsLog(musicReleases);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Обработка релизов сериалов
        /// </summary>
        /// <param name="settings">Настройки сервиса</param>
        /// <returns></returns>
        private async Task NotifyOfTvSeriesReleases(NotificationsSettingsEntity settings)
        {
            try
            {
                var currDateTime = DateTime.Now;

                var episodes = GetTvSeriesEpisodesReleases(currDateTime);

                var taskList = new List<Task> { _mailNotificationService.NotifyAboutReleaseAsync(episodes) };
                
                var pushNotifications = CastTvSeriasToPushModel(episodes);
                if (pushNotifications.Any())
                {
                    taskList.Add(SendPushNotifications(settings, pushNotifications));
                }

                await Task.WhenAll(taskList.ToList());
                SaveNotificationsLog(episodes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Получение релизов сериалов, по которым необходимо разослать уведомления
        /// </summary>
        /// <param name="currDateTime"></param>
        /// <returns></returns>
        private IEnumerable<EpisodeEntity> GetTvSeriesEpisodesReleases(DateTime currDateTime)
        {
            var episodes = _unitOfWork.EpisodeRepository.Queryable()
                .Include(e => e.Season)
                .Where(e => e.ReleaseDateRu > DbFunctions.AddDays(currDateTime, -3) && e.ReleaseDateRu < currDateTime)
                .ToList();

            //исключить релизы, которые, возможно, уже были обработаны ранее
            episodes = episodes
                .Where(m => _unitOfWork.NotificationsLogRepository.Queryable()
                    .All(n => m.Id != n.ReleaseId)).ToList();

            var tvSerias = episodes.Select(episode =>
                    _unitOfWork.TvSeriasRepository.Queryable()
                    .Include(tv => tv.ListPerson)
                    .FirstOrDefault(tv => tv.Id == episode.Season.TvSeriesId))
                .ToList();

            //добавляем в подписчики тех, кто подписан на актеров
            foreach (var tvSeria in tvSerias)
            {
                foreach (var personEntity in tvSeria.ListPerson)
                {
                    var users = personEntity.Users.Except(tvSeria.Users);
                    foreach (var user in users)
                    {
                        tvSeria.Users.Add(user);
                    }
                }

                episodes.ForEach(episode =>
                {
                    if (episode.Season.TvSeriesId == tvSeria.Id)
                    {
                        episode.Users = tvSeria.Users;
                    }
                });
            }

            return episodes;
        }

        /// <summary>
        /// Получение музыкальных релизов, по которым необходимо разослать уведомления
        /// </summary>
        /// <param name="currDateTime"></param>
        /// <returns></returns>
        private IEnumerable<DbMusic> GetMusicReleases(DateTime currDateTime)
        {
            var musicReleases = _unitOfWork.MusicRepository.Queryable()
                .Include(m => m.Users)
                .Include(m => m.Musicians)
                .Where(m => m.ReleaseDate > DbFunctions.AddDays(currDateTime, -3) && m.ReleaseDate < currDateTime)
                .Where(m => m.Users.Any() || m.Musicians.Select(a => a.Users.Any()).Any())
                .ToList();  

            //исключить релизы, которые, возможно, уже были обработаны ранее
            musicReleases = musicReleases
                .Where(m => _unitOfWork.NotificationsLogRepository.Queryable()
                    .All(n => m.Id != n.ReleaseId)).ToList();

            AddSubscribabersByMusicReleases(musicReleases);

            return musicReleases;
        }


        /// <summary>
        /// Добавляет подписчиков на музыкальный релиз, если те подписаны на исполнителя из этого релиза
        /// </summary>
        /// <param name="musicReleases"></param>
        private static void AddSubscribabersByMusicReleases(IEnumerable<DbMusic> musicReleases)
        {
            foreach (var musicRelease in musicReleases)
            {
                foreach (var musician in musicRelease.Musicians)
                {
                    var users = musician.Users.Except(musicRelease.Users);
                    foreach (var user in users)
                    {
                        musicRelease.Users.Add(user);
                    }
                }
            }
        }

        /// <summary>
        /// Преобразование списка музыкальных релизов в список уведомлений
        /// </summary>
        /// <param name="episodes">список релизов</param>
        /// <returns>список уведомлений</returns>
        private IEnumerable<PushNotificationModel> CastTvSeriasToPushModel(
            IEnumerable<EpisodeEntity> episodes)
        {
            var pushNotifications = (from episode in episodes
                                     let tvSeria = _unitOfWork.TvSeriasRepository.Queryable()
                                         .Include(tv => tv.ListPerson)
                                         .FirstOrDefault(tv => tv.Id == episode.Season.TvSeriesId)
                                     let msg = $"{tvSeria.TitleRu} - {episode.TitleRu} ({episode.Number} серия {episode.Season.Number} сезона)"
                                     select new PushNotificationModel
                                     {
                                         Message = msg,
                                         Users = episode.Users.Select(u => u.Id.ToString()).ToArray() 
                                     }).ToList();

            return pushNotifications;
        }


        /// <summary>
        /// Преобразование списка музыкальных релизов в список уведомлений
        /// </summary>
        /// <param name="musicReleases">список релизов</param>
        /// <returns>список уведомлений</returns>
        private static IEnumerable<PushNotificationModel> CastMusicToPushModel(IEnumerable<DbMusic> musicReleases)
        {
            var pushNotifications = (from musicRelease in musicReleases
                                     let msg = musicRelease.Artist + " " + musicRelease.Title
                                     select new PushNotificationModel
                                     {
                                         Message = msg,
                                         Users = musicRelease.Users.Select(u => u.Id.ToString()).ToArray() 
                                     }).ToList();

            return pushNotifications;
        }

        /// <summary>
        /// Отпарвка push-уведомления
        /// </summary>
        /// <param name="settings">Настройки сервиса</param>
        /// <param name="pushNotifications">список уведомлений</param>
        /// <returns></returns>
        private async Task<bool> SendPushNotifications(NotificationsSettingsEntity settings,
            IEnumerable<PushNotificationModel> pushNotifications)
        {
            var content = new StringContent(pushNotifications.ToString(), Encoding.UTF8, Resources.JsonMIMEType);
            var response = await _httpClient.PostAsync(settings.PushUrl, content);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent 
                || response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Сохранение релиза в лог нотификации
        /// </summary>
        /// <param name="subscribables">Список релизов</param>
        private void SaveNotificationsLog(IEnumerable<SubscribableEntity> subscribables)
        {
            var notificationLog = subscribables.Select(subscribable => new NotificationsLogEntity
                {
                    ReleaseId = subscribable.Id,
                    CreatedDateTime = DateTime.Now
                }).ToList();

            _unitOfWork.NotificationsLogRepository.InsertRange(notificationLog);
            _unitOfWork.SaveChanges();
        }
    }
}

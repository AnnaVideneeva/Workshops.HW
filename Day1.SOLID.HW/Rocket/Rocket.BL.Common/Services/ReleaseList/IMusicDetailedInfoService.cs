using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rocket.BL.Common.Models.Pagination;
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Common.Services.ReleaseList
{
    /// <summary>
    /// Представляет сервис для работы с детальной информацией
    /// о музыкальных релизах в хранилище данных
    /// </summary>
    public interface IMusicDetailedInfoService : IDisposable
    {
        /// <summary>
        /// Возвращает музыкальный релиз с заданным идентификатором из хранилища данных
        /// </summary>
        /// <param name="id">Идентификатор музыкального релиза</param>
        /// <returns>Экземпляр музыкального релиза</returns>
        Music GetMusic(int id);

        /// <summary>
        /// Возвращает страницу музыкальных релизов с заданным номером и размером,
        /// музыкальные релизы сортированы по дате релиза
        /// </summary>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="genreId">Идентификатор жанра</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Страница музыкальных релизов</returns>
        MusicPageInfo GetPageInfoByDate(int pageSize, int pageNumber, int? genreId = null, string userId = null);

        /// <summary>
        /// Возвращает страницу музыкальных релизов с заданным номером и размером,
        /// музыкальные релизы сортированы по дате релиза
        /// </summary>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="genreId">Идентификатор жанра</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Страница музыкальных релизов</returns>
        MusicPageInfo GetNewPageInfoByDate(int pageSize, int pageNumber, int? genreId = null, string userId = null);

        /// <summary>
        /// Добавляет заданный музыкальный релиз в хранилище данных
        /// и возвращает идентификатор добавленного музыкального релиза.
        /// </summary>
        /// <param name="music">Экземпляр музыкального релиза для добавления</param>
        /// <returns>Идентификатор музыкального релиза</returns>
        int AddMusic(Music music);

        /// <summary>
        /// Обновляет информацию заданного музыкального релиза в хранилище данных
        /// </summary>
        /// <param name="music">Экземпляр музыкального релиза для обновления</param>
        void UpdateMusic(Music music);

        /// <summary>
        /// Удаляет музыкальный релиз с заданным идентификатором из хранилища данных.
        /// </summary>
        /// <param name="id">Идентификатор музыкального релиза</param>
        void DeleteMusic(int id);

        /// <summary>
        /// Проверяет наличие заданного музыкального релиза в хранилище данных
        /// </summary>
        /// <param name="filter">Лямбда-выражение определяющее фильтр для поиска музыки</param>
        /// <returns>Возвращает <see langword="true"/>, если музыкальный релиз существует в хранилище данных</returns>
        bool MusicExists(Expression<Func<Music, bool>> filter);

        /// <summary>
        /// Возвращает коллекцию музыкальных релизов с датой выхода
        /// между заданными начальной и конечной датами включительно
        /// </summary>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Коллекция музыкальных релизов</returns>
        IEnumerable<Music> GetMusicByDates(DateTime startDate, DateTime endDate, string userId = null);
    }
}
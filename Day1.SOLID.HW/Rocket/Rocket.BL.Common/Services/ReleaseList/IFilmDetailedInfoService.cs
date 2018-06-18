using Rocket.BL.Common.Models.ReleaseList;
using System;
using System.Linq.Expressions;

namespace Rocket.BL.Common.Services.ReleaseList
{
    /// <summary>
    /// Представляет сервис для работы с детальной информацией
    /// о фильмах в хранилище данных
    /// </summary>
    public interface IFilmDetailedInfoService : IDisposable
    {
        /// <summary>
        /// Возвращает фильма с заданным идентификатором из хранилища данных
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        /// <returns>Экземпляр фильма</returns>
        Film GetFilm(int id);

        /// <summary>
        /// Добавляет заданный фильм в хранилище данных
        /// и возвращает идентификатор добавленного фильма.
        /// </summary>
        /// <param name="film">Экземпляр фильма для добавления</param>
        /// <returns>Идентификатор фильма</returns>
        int AddFilm(Film film);

        /// <summary>
        /// Обновляет информацию заданного фильма в хранилище данных
        /// </summary>
        /// <param name="film">Экземпляр фильма для обновления</param>
        void UpdateFilm(Film film);

        /// <summary>
        /// Удаляет фильм с заданным идентификатором из хранилища данных.
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        void DeleteFilm(int id);

        /// <summary>
        /// Проверяет наличие фильма в хранилище данных
        /// соответствующего заданному фильтру
        /// </summary>
        /// <param name="filter">Лямбда-выражение определяющее фильтр для поиска фильма</param>
        /// <returns>Возвращает <see langword="true"/>, если фильм существует в хранилище данных</returns>
        bool FilmExists(Expression<Func<Film, bool>> filter);
    }
}
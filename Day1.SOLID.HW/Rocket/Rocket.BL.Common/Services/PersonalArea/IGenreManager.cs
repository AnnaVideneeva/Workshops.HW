using System.Collections;

namespace Rocket.BL.Common.Services.PersonalArea
{
    /// <summary>
    /// Интерфейс для работы с жанрами.
    /// </summary>
    public interface IGenreManager
    {
        /// <summary>
        /// Получение всех музыкальных жанров из базы.
        /// </summary>
        /// <returns>Коллекцию музыкальных жанров.</returns>
        IEnumerable GetAllMusicGenres();

        /// <summary>
        /// Получение всех TV жанров из базы.
        /// </summary>
        /// <returns>Коллекцию TV жанров.</returns>
        IEnumerable GetAllTvGenres();

        /// <summary>
        /// Добавление жанра TV в персональный список ожидания релизов.
        /// </summary>
        /// <param name="id">id идентификатор пользователя.</param>
        /// <param name="genre">TV жанр продукта, который пользователь хочет добавить в список.</param>
        void AddTvGenre(string id, string genre);

        /// <summary>
        /// Удаление жанра TV из персонального списка ожидания релизов.
        /// </summary>
        /// <param name="id">id идентификатор пользователя.</param>
        /// <param name="genre">TV жанр продукта, который пользователь хочет удалить из списка.</param>
        void DeleteTvGenre(string id, string genre);

        /// <summary>
        /// Добавление музыкального жанра в персональный список ожидания релизов.
        /// </summary>
        /// <param name="id">id идентификатор пользователя.</param>
        /// <param name="genre">Музыкальный жанр продукта, который пользователь хочет добавить в список.</param>
        void AddMusicGenre(string id, string genre);

        /// <summary>
        /// Удаление музыкального жанра из персонального списка ожидания релизов.
        /// </summary>
        /// <param name="id">id идентификатор пользователя.</param>
        /// <param name="genre">Музыкальный жанр продукта, который пользователь хочет удалить из списка.</param>
        void DeleteMusicGenre(string id, string genre);
    }
}
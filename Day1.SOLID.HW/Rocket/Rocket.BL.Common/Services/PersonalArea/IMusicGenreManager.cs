using System.Collections;

namespace Rocket.BL.Common.Services.PersonalArea
{
    /// <summary>
    /// Интерфейс для работы с жанрами музыки.
    /// </summary>
    public interface IMusicGenreManager
    {
        /// <summary>
        /// Получение всех музыкальных жанров из базы.
        /// </summary>
        /// <returns>Коллекцию музыкальных жанров.</returns>
        IEnumerable GetAllMusicGenres();

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

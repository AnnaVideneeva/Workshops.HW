using Rocket.BL.Common.Models.PersonalArea;

namespace Rocket.BL.Common.Services.PersonalArea
{
    /// <summary>
    /// Интерфейс для работы с email-адресами.
    /// </summary>
    public interface IEmailManager
    {
        /// <summary>
        /// Добавление нового e-mail для отправки нотификаций.
        /// </summary>
        /// <param name="id">Id пользователя, инициировавшего добавление нового e-mail.</param>
        /// <param name="email">Адрес e-mail, который необходимо добавить.</param>
        /// <returns>Id нового e-mail</returns>
        int AddEmail(string id, Email email);

        /// <summary>
        /// Удаление из приложения одного из имеющихся e-mail пользователя.
        /// </summary>
        /// <param name="id">Id email,для удаления.</param>
        void DeleteEmail(int id);
    }
}
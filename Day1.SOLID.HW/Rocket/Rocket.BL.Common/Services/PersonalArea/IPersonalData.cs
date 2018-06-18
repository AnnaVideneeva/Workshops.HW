using Rocket.BL.Common.Models.PersonalArea;

namespace Rocket.BL.Common.Services.PersonalArea
{
    /// <summary>
    /// Интерфейс для работы с личными данными AuthorisedUser.
    /// </summary>
    public interface IPersonalData
    {
        /// <summary>
        /// Получение модели авторизованного пользователя по Id.
        /// </summary>
        /// <param name="id">Id по которому необходимо найти пользователя.</param>
        /// <returns>Модель авторизованного пользователя.</returns>
        UserProfile GetUserData(string id);

        /// <summary>
        /// Изменение персональных данных.
        /// </summary>
        /// <param name="id">Id пользователя, инициировавшего смену личных данных.</param>
        /// <param name="firstName">Имя пользователя.</param>
        /// <param name="lastName">Фамилия пользователя.</param>
        /// <param name="avatar">Аватар пользователя.</param>
        void ChangePersonalData(string id, string firstName, string lastName, string avatar);

        /// <summary>
        /// Изменение пароля на новый.
        /// </summary>
        /// <param name="id">Id пользователя, инициировавшего смену пароля.</param>
        /// <param name="newPassword">Новый пароль, введенный пользователем.</param>
        /// <param name="newPasswordConfirm">Подтверждение пароля.</param>
        void ChangePasswordData(string id, string newPassword, string newPasswordConfirm);
    }
}
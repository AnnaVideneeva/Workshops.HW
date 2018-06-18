using System;

namespace Rocket.BL.Common.Services.User
{
    /// <summary>
    /// Представляет сервис для валидации сведений о пользователе
    /// пользователя при его регистрации, а также изменении.
    /// </summary>
    public interface IUserValidateService
    {
        /// <summary>
        /// Валидирует (проверяет) экземпляр пользователя
        /// при его (вернее, перед) добавлении (регистрации) в хранилище данных.
        /// Минимальный набор данных.
        /// </summary>
        /// <param name="user">Экземпляр пользователя, который проверяется.</param>
        /// <returns>Возвращает <see langword='true'/>, если проверка завершена успешно.</returns>
        bool UserValidateOnAddition(Models.User.User user);

        /// <summary>
        /// Валидирует (проверяем) экземпляр пользователя
        /// при его (вернее, перед) изменением.
        /// </summary>
        /// <param name="user">Экземпляр пользователя, который проверяется.</param>
        /// <returns>Возвращает <see langword='true'/>, если проверка завершена успешно.</returns>
        bool UserValidateOnUpdating(Models.User.User user);
    }
}
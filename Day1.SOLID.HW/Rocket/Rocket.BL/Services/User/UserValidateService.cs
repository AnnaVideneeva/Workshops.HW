using Rocket.BL.Validators.User;

namespace Rocket.BL.Services.User
{
    /// <summary>
    /// Представляет сервис для валидации сведений о пользователе
    /// пользователя при его регистрации, а также изменении.
    /// </summary>
    public class UserValidateService : Common.Services.User.IUserValidateService
    {
        /// <summary>
        /// Валидирует (проверяет) экземпляр пользователя
        /// при его (вернее, перед) добавлении (регистрации) в хранилище данных.
        /// Минимальный набор данных.
        /// </summary>
        /// <param name="user">Экземпляр пользователя, который проверяется.</param>
        /// <returns>Возвращает <see langword='true'/>, если проверка завершена успешно.</returns>
        public bool UserValidateOnAddition(Common.Models.User.User user)
        {
            return UserValidateOnAdditionCheckRequiredFields(user)
                   && UserValidateOnAdditionCheckLogicAndFormat(user);
        }

        /// <summary>
        /// Валидирует (проверяем) экземпляр пользователя
        /// при его (вернее, перед) изменением.
        /// </summary>
        /// <param name="user">Экземпляр пользователя, который проверяется.</param>
        /// <returns>Возвращает <see langword='true'/>, если проверка завершена успешно.</returns>
        public bool UserValidateOnUpdating(Common.Models.User.User user)
        {
            return true;
        }

        /// <summary>
        /// Проверяем наличие обязательных полей в модели.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Возвращает истинно, если проверка прошла успешно.</returns>
        public bool UserValidateOnAdditionCheckRequiredFields(Common.Models.User.User user)
        {
            UserValidatorCheckRequiredFields validator = new UserValidatorCheckRequiredFields();

            return validator.Validate(user).IsValid;
        }

        /// <summary>
        /// Проверяем формат и другие условия валидации данных модели пользователя.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Возвращает истинно, если проверка прошла успешно.</returns>
        public bool UserValidateOnAdditionCheckLogicAndFormat(Common.Models.User.User user)
        {
            UserValidatorLogicAndFormat validator = new UserValidatorLogicAndFormat();

            return validator.Validate(user).IsValid;
        }
    }
}
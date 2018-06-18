namespace Rocket.BL.Common.Services.UserPayment
{
    /// <summary>
    /// Представляет сервис для валидации сведений о пользователе
    /// пользователя при его регистрации, а также изменении.
    /// </summary>
    public interface IUserPaymentService
    {
        /// <summary>
        /// получение инфы о платеже.
        /// </summary>
        /// <param name="user">Экземпляр пользователя, для которого ищем инфу о платеже.</param>
        /// <returns>Платеж пользователя.</returns>
        Models.UserPayment GetUserPayment(Models.User.User user);

        /// <summary>
        /// добавление инфы о платеже.
        /// </summary>
        /// <param name="payment">Информация о платеже</param>
        void AddUserPayment(Models.UserPayment payment);
    }
}
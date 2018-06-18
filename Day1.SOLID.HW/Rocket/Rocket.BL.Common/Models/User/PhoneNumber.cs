namespace Rocket.BL.Common.Models.User
{
    /// <summary>
    /// Представляет информацию о телефонном номере дополнительной информации пользователя.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор телефонного номера дополнительной информации пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает содержание телефонного номера дополнительной информации пользователя.
        /// </summary>
        public string Number { get; set; }
    }
}
namespace Rocket.BL.Common.Models.User
{
    /// <summary>
    /// Представляет сведения о том, как обращаться к пользователю
    /// (Mr, Miss, Ms).
    /// </summary>
    public class HowToCall
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор сведений о том, как обращаться к пользователю.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает обращение к пользователю.
        /// </summary>
        public string Name { get; set; }
    }
}
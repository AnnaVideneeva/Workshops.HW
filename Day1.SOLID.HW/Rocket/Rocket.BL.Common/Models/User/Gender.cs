namespace Rocket.BL.Common.Models.User
{
    /// <summary>
    /// Представляет пол пользователя.
    /// (Mr, Miss, Ms).
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор пола пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает пол пользователя.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace Rocket.BL.Common.Models.User
{
    /// <summary>
    /// Представляет информацию об уровне пользователя: обыкнованный, премиум
    /// и типе аккауинта.
    /// </summary>
    public class AccountLevel
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор уровня пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает название уровня пользователя.
        /// </summary>
        public string Name { get; set; }
    }
}
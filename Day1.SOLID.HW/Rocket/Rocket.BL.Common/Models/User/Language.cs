namespace Rocket.BL.Common.Models.User
{
    /// <summary>
    /// Представляет сведения о языке.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Задает или возвращает уникальный идентификатор языка пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Задает или возвращает название языка пользователя.
        /// </summary>
        public string Name { get; set; }
    }
}
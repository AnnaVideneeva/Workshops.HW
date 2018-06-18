namespace Rocket.BL.Common.Models.ReleaseList
{
    /// <summary>
    /// Представляет информацию о стране
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор страны
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает название страны
        /// </summary>
        public string Name { get; set; }
    }
}
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Common.Models.User
{
    /// <summary>
    /// Тип адреса. Классика.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Задает или возвращает уникальный идентификационный номер адреса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Задает или возвращает почтовый индекс.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Возвращает или задает страну.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Возвращает или задает город.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Возвращает или задает номер строения (дома).
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Возвращает или задает номер корпуса.
        /// </summary>
        public string BuildingBlock { get; set; }

        /// <summary>
        /// Возвращает или задает номер квартиры.
        /// </summary>
        public string Flat { get; set; }
    }
}
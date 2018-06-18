using Rocket.DAL.Common.DbModels.ReleaseList;

namespace Rocket.DAL.Common.DbModels.User
{
    /// <summary>
    /// Представляет модель хранениея данных адреса для сведений о пользователе.
    /// </summary>
    public class DbAddress
    {
        /// <summary>
        /// Задает или возвращает уникальный идентификационный адреса.
        /// </summary>
        /// <value>Уникальный идентификатор адреса пользователя.</value>>
        public int Id { get; set; }

        /// <summary>
        /// Задает или возвращает почтовый индекс.
        /// </summary>
        /// <value>Почтовый индекс адареса пользователя.</value>>
        public string ZipCode { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор страны,
        /// к которому относится этот адрес.
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Возвращает или задает страну.
        /// </summary>
        /// <value>Страна адреса пользователя.</value>>
        public virtual DbCountry Country { get; set; }

        /// <summary>
        /// Возвращает или задает город.
        /// </summary>
        /// <value>Город адреса пользователя.</value>>
        public string City { get; set; }

        /// <summary>
        /// Возвращает или задает номер строения (дома).
        /// </summary>
        /// <value>Номер строения (дома).</value>>
        public string Building { get; set; }

        /// <summary>
        /// Возвращает или задает номер корпуса.
        /// </summary>
        /// <value>Номер корпуса.</value>>
        public string BuildingBlock { get; set; }

        /// <summary>
        /// Возвращает или задает номер квартиры.
        /// </summary>
        /// <value>Номер квартиры.</value>>
        public string Flat { get; set; }

        /// <summary>
        /// Задает или возвращает дополнительную информацию пользователя,
        /// к которой относится этот адрес.
        /// </summary>
        /// <value>Дополнительная информация пользователя, к которой относится этот адрес.</value>>
        public virtual DbUserDetail DbUserDetail { get; set; }
    }
}
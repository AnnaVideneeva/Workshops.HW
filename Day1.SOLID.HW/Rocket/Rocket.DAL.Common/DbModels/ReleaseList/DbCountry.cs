using System;
using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Common.DbModels.ReleaseList
{
    /// <summary>
    /// Представляет модель хранения данных о странах
    /// </summary>
    public class DbCountry
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор страны
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает название страны
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию детальной информации о пользователях,
        /// к которым относится данная страна.
        /// </summary>
        public ICollection<DbUserDetail> DbUserDetails { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию адресов детальной информации пользователей,
        /// к которым относится данная страна.
        /// </summary>
        public ICollection<DbAddress> DbAddresses { get; set; }

        public static explicit operator DbCountry(DbUser v)
        {
            throw new NotImplementedException();
        }
    }
}
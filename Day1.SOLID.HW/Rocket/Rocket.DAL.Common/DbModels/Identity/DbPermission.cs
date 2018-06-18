using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.Identity
{
    public class DbPermission
    {
        /// <summary>
        /// Уникальный идентификатор значения "право доступа" 
        /// (либо функциональная возможность)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Описание  функц. возможности, соответствующее идентификатору 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Именование переменной, за которой скрывается реализация фичи
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// Список ролей для пермишена
        /// </summary>
        public virtual ICollection<DbRole> Roles { get; set; }
    }
}
using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.Identity;

namespace Rocket.DAL.Migrations.InitialDataCreators.UserRole
{
    /// <summary>
    /// Формирует коллекции первоначальных данных ролей пользователя
    /// для заполнения ими соответствующего репозитация.
    /// </summary>
    public class DbUserRolesCreator
    {
        /// <summary>
        /// Возвращает коллекцию сведений о ролях пользователей.
        /// </summary>
        public List<DbRole> Items { get; } = new List<DbRole>()
        {
            //new DbRole() { Id = 1, Name = "unregister" },
            //new DbRole() { Id = 2, Name = "user" },
            //new DbRole() { Id = 3, Name = "moderator" },
            //new DbRole() { Id = 4, Name = "admin" }
        };
    }
}

using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.Identity;
using Rocket.DAL.Common.DbModels.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rocket.DAL.Migrations.InitialDataCreators.User
{
    /// <summary>
    /// Представляет набор сгенерированных данных о пользователях,
    /// в моделях хранинения данных.
    /// </summary>
    public class FakeDbUsersCreator
    {
        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о пользователях.
        /// </summary>
        
        public FakeDbUsersCreator()
        {
            var roles = new List<DbUser>()
            {
                new DbUser() { FirstName = "Peter", LastName = "Ivanych", UserName = "Peter456", PasswordHash = "13434"},
                new DbUser() { FirstName = "Peter", LastName = "Ivanych", UserName = "Peter4563", PasswordHash = "234534"},
                new DbUser() { FirstName = "Peter", LastName = "Ivanych", UserName = "Peter3456", PasswordHash = "23452"},
                new DbUser() { FirstName = "Peter", LastName = "Ivanych", UserName = "Peter345643", PasswordHash = "2345"},
                new DbUser() { FirstName = "Peter", LastName = "Ivanych", UserName = "Peter", PasswordHash = "235"}
        };
        }

        /// <summary>
        /// Возвращает коллекцию сгенерированных пользователей.
        /// </summary>
        public List<DbUser> Users { get; }
    }
}
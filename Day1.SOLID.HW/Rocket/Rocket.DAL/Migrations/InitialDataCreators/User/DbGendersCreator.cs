using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Migrations.InitialDataCreators.User
{
    /// <summary>
    /// Формирует коллекции первоначальных данных половой принадлежности пользователя
    /// для заполнения ими соответствующего репозитация.
    /// </summary>
    public class DbGendersCreator
    {
        /// <summary>
        /// Задает коллекцию сведений о половой идентификации пользователя.
        /// </summary>
        public List<DbGender> Items { get; } = new List<DbGender>()
        {
            new DbGender() { Id = 1, Name = "Мужчина" },
            new DbGender() { Id = 2, Name = "Женщина" }
        };
    }
}

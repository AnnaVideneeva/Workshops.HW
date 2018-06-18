using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Migrations.InitialDataCreators.User
{
    /// <summary>
    /// Формирует коллекции первоначальных данных статуса аккаунта пользователя
    /// для заполнения ими соответствующего репозитация.
    /// </summary>
    public class DbAccountStatusesCreator
    {
        /// <summary>
        /// Возвращает коллекцию сведений о статусе акканта пользователя.
        /// </summary>
        public List<DbAccountStatus> Items { get; } = new List<DbAccountStatus>()
        {
            new DbAccountStatus() { Id = 1, Name = "Зарегистрирован" },
            new DbAccountStatus() { Id = 2, Name = "Деактивирован" },
            new DbAccountStatus() { Id = 3, Name = "Заблокирован" },
        };
    }
}

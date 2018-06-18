using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Migrations.InitialDataCreators.User
{
    /// <summary>
    /// Формирует коллекции первоначальных данных уровня аккаунта пользователя
    /// для заполнения ими соответствующего репозитация (сори за полу "говнокод").
    /// </summary>
    public class DbAccountLevelsCreator
    {
        /// <summary>
        /// Возвращает коллекцию сведений об уровне акканта пользователя.
        /// </summary>
        public List<DbAccountLevel> Items { get; } = new List<DbAccountLevel>()
        {
            new DbAccountLevel() { Id = 1, Name = "Обычный" },
            new DbAccountLevel() { Id = 2, Name = "Премиум" }
        };
    }
}

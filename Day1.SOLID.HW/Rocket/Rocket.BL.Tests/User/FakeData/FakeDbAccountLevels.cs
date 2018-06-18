using Bogus;
using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных об уровнях аккаунта пользователя,
    /// в моделях хранения данных
    public class FakeDbAccountLevels
    {
        /// <summary>
        /// Возвращает генератор данных об уровнях аккаунта пользователя
        /// </summary>
        public Faker<DbAccountLevel> AccountLevelFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных уровней аккаунта пользователя
        /// </summary>
        public List<DbAccountLevel> AccountLevels { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных об уровнях аккаунта пользователя
        /// </summary>
        /// <param name="accountLevelCount">Необходимое количество уровней аккаунта пользователя</param>
        public FakeDbAccountLevels(int accountLevelCount)
        {
            AccountLevelFaker = new Faker<DbAccountLevel>()
                .RuleFor(g => g.Id, f => f.IndexFaker)
                .RuleFor(g => g.Name, f => f.Random.Word());

            AccountLevels = AccountLevelFaker.Generate(accountLevelCount);
        }
    }
}
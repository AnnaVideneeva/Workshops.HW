using Bogus;
using System.Collections.Generic;
using Rocket.BL.Common.Models.User;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных об уровнях аккаунта пользователя,
    /// в моделях домена
    /// </summary>
    public class FakeAccountLevels
    {
        /// <summary>
        /// Возвращает генератор данных об уровнях аккаунта пользователя
        /// </summary>
        public Faker<AccountLevel> AccountLevelFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных уровней аккаунта пользователя
        /// </summary>
        public List<AccountLevel> AccountLevels { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных об уровнях аккаунта пользователя
        /// </summary>
        /// <param name="accountLevelCount">Необходимое количество уровней аккаунта пользователя</param>
        public FakeAccountLevels(int accountLevelCount)
        {
            AccountLevelFaker = new Faker<AccountLevel>()
                .RuleFor(g => g.Id, f => f.IndexFaker)
                .RuleFor(g => g.Name, f => f.Random.Word());

            AccountLevels = AccountLevelFaker.Generate(accountLevelCount);
        }
    }
}
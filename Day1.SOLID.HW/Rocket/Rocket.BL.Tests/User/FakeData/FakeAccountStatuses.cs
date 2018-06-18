using Bogus;
using System.Collections.Generic;
using Rocket.BL.Common.Models.User;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных об уровнях аккаунта пользователя,
    /// в моделях домена
    /// </summary>
    public class FakeAccountStatuses
    {
        /// <summary>
        /// Возвращает генератор данных об уровнях аккаунта пользователя
        /// </summary>
        public Faker<AccountStatus> AccountStatusFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных уровней аккаунта пользователя
        /// </summary>
        public List<AccountStatus> AccountStatuses { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных об уровнях аккаунта пользователя
        /// </summary>
        /// <param name="accountStatusCount">Необходимое количество уровней аккаунта пользователя</param>
        public FakeAccountStatuses(int accountStatusCount)
        {
            AccountStatusFaker = new Faker<AccountStatus>()
                .RuleFor(g => g.Id, f => f.IndexFaker)
                .RuleFor(g => g.Name, f => f.Random.Word());

            AccountStatuses = AccountStatusFaker.Generate(accountStatusCount);
        }
    }
}
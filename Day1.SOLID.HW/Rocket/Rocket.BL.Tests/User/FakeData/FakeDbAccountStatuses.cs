using Bogus;
using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляв моделях хранения данныхет набор сгенерированных данных об уровнях аккаунта пользователя,
    /// в моделях хранения данных
    /// </summary>
    public class FakeDbAccountStatuses
    {
        /// <summary>
        /// Возвращает генератор данных об уровнях аккаунта пользователя
        /// </summary>
        public Faker<DbAccountStatus> AccountStatusFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных уровней аккаунта пользователя
        /// </summary>
        public List<DbAccountStatus> AccountStatuses { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных об уровнях аккаунта пользователя
        /// </summary>
        /// <param name="accountStatusCount">Необходимое количество уровней аккаунта пользователя</param>
        public FakeDbAccountStatuses(int accountStatusCount)
        {
            AccountStatusFaker = new Faker<DbAccountStatus>()
                .RuleFor(g => g.Id, f => f.IndexFaker)
                .RuleFor(g => g.Name, f => f.Random.Word());

            AccountStatuses = AccountStatusFaker.Generate(accountStatusCount);
        }
    }
}
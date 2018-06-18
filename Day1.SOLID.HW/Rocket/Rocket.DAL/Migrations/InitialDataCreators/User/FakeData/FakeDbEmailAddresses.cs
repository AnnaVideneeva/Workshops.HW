using System.Collections.Generic;
using Bogus;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Migrations.InitialDataCreators.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных об электронных адресах дополнительной информации пользователей,
    /// в моделях хранения данных.
    /// </summary>
    public class FakeDbEmailAddresses
    {
        /// <summary>
        /// Создает новый экземпляр сгенерированных электронных адресов дополнительной информации пользователей.
        /// </summary>
        /// <param name="emailAddressCount">Необходимое количество сгенерированных адресов электронной почты дополнительной информации пользователей.</param>
        public FakeDbEmailAddresses(int emailAddressCount)
        {
            EmailAddressFaker = new Faker<DbEmailAddress>()
                .RuleFor(ea => ea.Id, f => f.IndexFaker)
                .RuleFor(ea => ea.Address, f => f.Internet.Email());

            EmailAddresses = EmailAddressFaker.Generate(emailAddressCount);
        }

        /// <summary>
        /// Возвращает генератор данных об электронных адресах дополнительной информации пользователей.
        /// </summary>
        public Faker<DbEmailAddress> EmailAddressFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных электронных адресов пользователей.
        /// </summary>
        public List<DbEmailAddress> EmailAddresses { get; }
    }
}
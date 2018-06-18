using Bogus;
using Rocket.BL.Common.Models.User;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных об электронных адресах дополнительной информации пользователей,
    /// в моделях домена.
    /// </summary>
    public class FakeEmailAddresses
    {
        /// <summary>
        /// Возвращает генератор данных об электронных адресах дополнительной информации пользователей.
        /// </summary>
        public Faker<EmailAddress> EmailAddressFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных электронных адресов дополнительной информации пользователей.
        /// </summary>
        public List<EmailAddress> EmailAddresses { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных электронных адресов дополнительной информации пользователей.
        /// </summary>
        /// <param name="emailAddressCount">Необходимое количество сгенерированных адресов электронной почты дополнительной информации пользователей.</param>
        public FakeEmailAddresses(int emailAddressCount)
        {
            EmailAddressFaker = new Faker<EmailAddress>()
                .RuleFor(ea => ea.Id, f => f.IndexFaker)
                .RuleFor(ea => ea.Address, f =>f.Internet.Email());

            EmailAddresses = EmailAddressFaker.Generate(emailAddressCount);
        }
    }
}
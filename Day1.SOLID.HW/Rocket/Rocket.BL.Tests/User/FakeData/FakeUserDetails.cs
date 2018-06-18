using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных дополнительных данных о пользователях,
    /// в моделях домена
    /// </summary>
    public class FakeUserDetails
    {
        /// <summary>
        /// Возвращает генератор дополнительных данных о пользователях
        /// </summary>
        public Faker<Common.Models.User.UserDetail> UserFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных дополнительных данных о пользователях
        /// </summary>
        public List<Common.Models.User.UserDetail> UserDetails { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных дополнительных данных о пользователе
        /// </summary>
        /// <param name="userCount">Возвращает количество генерируемых дополнительных данных о пользователях</param>
        public FakeUserDetails(int usersCount)
        {
            var result = new Faker<Common.Models.User.UserDetail>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Language, f => f.PickRandomParam(new FakeLanguages(30).Languages.ToArray()))
                .RuleFor(p => p.Sitizenship, f => f.PickRandomParam(new FakeCountries(15).Countries.ToArray()))
                .RuleFor(p => p.HowToCall, f => f.PickRandomParam(new FakeHowToCalls(3).HowToCalls.ToArray()))
                .RuleFor(p => p.MailAddress, f => { return new FakeAddresses(1).Addresses[0]; })
                .RuleFor(p => p.PhoneNumbers, f => { return new FakePhoneNumbers(new Random().Next(1, 5)).PhoneNumbers.ToList(); })
                .RuleFor(p => p.EMailAddresses,
                    f => { return new FakeEmailAddresses(new Random().Next(1, 5)).EmailAddresses.ToList(); })
                .RuleFor(p => p.Gender, f => f.PickRandomParam(new FakeGenders(3).Genders.ToArray()))
                .RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth);

            UserDetails = result.Generate(usersCount);
        }
    }
}
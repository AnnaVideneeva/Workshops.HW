using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Migrations.InitialDataCreators.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных дополнительных данных о пользователях,
    /// в моделях домена
    /// </summary>
    public class FakeDbUserDetails
    {
        /// <summary>
        /// Создает новый экземпляр сгенерированных дополнительных данных о пользователях.
        /// </summary>
        /// <param name="dbCountries">Коллекция всех стран.</param>
        /// <param name="dbGenders">Коллекция сведений о половой идентификации дополнительной информации пользователей.</param>
        /// <param name="dbHowToCalls">Коллекция сведений о том, как надо обращаться к пользователям.</param>
        /// <param name="dbLanguages">Коллекиця всех используемых разговорных языков пользователей.</param>
        public FakeDbUserDetails(
            ICollection<DbCountry> dbCountries,
            ICollection<DbGender> dbGenders,
            ICollection<DbHowToCall> dbHowToCalls,
            ICollection<DbLanguage> dbLanguages)
        {
            var result = new Faker<DbUserDetail>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Language, f => dbLanguages.ToArray()[new Random().Next(1, 13)])
                .RuleFor(p => p.Sitizenship, f => dbCountries.ToArray()[new Random().Next(1, 251)])
                .RuleFor(p => p.HowToCall, f => dbHowToCalls.ToArray()[new Random().Next(1, 2)])
                .RuleFor(p => p.MailAddress, f => new FakeDbAddresses(dbCountries).Addresses[0])
                .RuleFor(p => p.PhoneNumbers, f => (new FakeDbPhoneNumbers(new Random().Next(1, 5))).PhoneNumbers.ToArray())
                .RuleFor(p => p.EMailAddresses, f => new FakeDbEmailAddresses(new Random().Next(1, 5)).EmailAddresses.ToArray())
                .RuleFor(p => p.Gender, f => dbGenders.ToArray()[new Random().Next(1, 2)])
                .RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth);

            UserDetails = result.Generate(1);
        }

        /// <summary>
        /// Возвращает коллекцию сгенерированных дополнительных данных о пользователях
        /// </summary>
        public List<DbUserDetail> UserDetails { get; }
    }
}
using Bogus;
using Rocket.DAL.Common.DbModels.User;
using System.Collections.Generic;

namespace Rocket.DAL.Migrations.InitialDataCreators.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о номерах телефона дополнительной информации пользователя,
    /// в моделях хранения данных.
    /// </summary>
    public class FakeDbPhoneNumbers
    {
        /// <summary>
        /// Создает новый экземпляр сгенерированных телефонных номеров дополнительной информации пользователей.
        /// </summary>
        /// <param name="phoneNumbersCount">Необходимое количество сгенерированных телефонных номеров дополнительной информации пользователей.</param>
        public FakeDbPhoneNumbers(int phoneNumbersCount)
        {
            PhoneNumberFaker = new Faker<DbPhoneNumber>()
                .RuleFor(pn => pn.Id, f => f.IndexFaker)
                .RuleFor(pn => pn.Number, f => f.Phone.PhoneNumber());

            PhoneNumbers = PhoneNumberFaker.Generate(phoneNumbersCount);
        }

        /// <summary>
        /// Возвращает генератор данных о номерах телефона дополнительной информации пользователя.
        /// </summary>
        public Faker<DbPhoneNumber> PhoneNumberFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных номеров телефонов дополнительной информации пользователей.
        /// </summary>
        public List<DbPhoneNumber> PhoneNumbers { get; }
    }
}
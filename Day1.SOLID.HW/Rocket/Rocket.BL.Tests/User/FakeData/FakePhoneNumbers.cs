using Bogus;
using Rocket.BL.Common.Models.User;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о номерах телефона дополнительной информации пользователя,
    /// в моделях домена.
    /// </summary>
    public class FakePhoneNumbers
    {
        /// <summary>
        /// Возвращает генератор данных о номерах телефона дополнительной информации пользователя.
        /// </summary>
        public Faker<PhoneNumber> PhoneNumberFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных номеров телефонов дополнительной информации пользователей.
        /// </summary>
        public List<PhoneNumber> PhoneNumbers { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных телефонных номеров дополнительной информации пользователей.
        /// </summary>
        /// <param name="phoneNumbersCount">Необходимое количество сгенерированных телефонных номеров дополнительной информации пользователей.</param>
        public FakePhoneNumbers(int phoneNumbersCount)
        {
            PhoneNumberFaker = new Faker<PhoneNumber>()
                .RuleFor(pn => pn.Id, f => f.IndexFaker)
                .RuleFor(pn => pn.Number, f => f.Phone.PhoneNumber());

            PhoneNumbers = PhoneNumberFaker.Generate(phoneNumbersCount);
        }
    }
}
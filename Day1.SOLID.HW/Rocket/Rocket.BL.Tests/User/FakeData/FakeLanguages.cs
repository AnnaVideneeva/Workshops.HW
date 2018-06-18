using Bogus;
using Rocket.BL.Common.Models.User;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о языках пользователей,
    /// в моделях домена
    /// </summary>
    public class FakeLanguages
    {
        /// <summary>
        /// Возвращает генератор данных о языках пользователей
        /// </summary>
        public Faker<Language> LanguageFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных языков пользователей
        /// </summary>
        public List<Language> Languages { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о языках пользователей
        /// </summary>
        /// <param name="countriesCount">Необходимое количество сгенерированных языков пользователей</param>
        public FakeLanguages(int languagesCount)
        {
            LanguageFaker = new Faker<Language>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Address.Country());

            Languages = LanguageFaker.Generate(languagesCount);
        }
    }
}
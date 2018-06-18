using Bogus;
using Rocket.DAL.Common.DbModels.User;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о языках пользователей,
    /// в моделях хранения данных
    /// </summary>
    public class FakeDbLanguages
    {
        /// <summary>
        /// Возвращает генератор данных о языках пользователей
        /// </summary>
        public Faker<DbLanguage> LanguageFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных языков пользователей
        /// </summary>
        public List<DbLanguage> Languages { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о языках пользователей
        /// </summary>
        /// <param name="languagesCount">Необходимое количество сгенерированных языков пользователей</param>
        public FakeDbLanguages(int languagesCount)
        {
            LanguageFaker = new Faker<DbLanguage>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Address.Country());

            Languages = LanguageFaker.Generate(languagesCount);
        }
    }
}
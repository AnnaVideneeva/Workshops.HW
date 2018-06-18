using Bogus;
using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.ReleaseList;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о странах,
    /// в моделях хранения данных
    /// </summary>
    public class FakeDbCountries
    {
        /// <summary>
        /// Возвращает генератор данных о странах
        /// </summary>
        public Faker<DbCountry> CountryFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных стран
        /// </summary>
        public List<DbCountry> Countries { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о странах
        /// </summary>
        /// <param name="countriesCount">Необходимое количество стран для генерации</param>
        public FakeDbCountries(int countriesCount)
        {
            CountryFaker = new Faker<DbCountry>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Address.Country());

            Countries = CountryFaker.Generate(countriesCount);
        }
    }
}
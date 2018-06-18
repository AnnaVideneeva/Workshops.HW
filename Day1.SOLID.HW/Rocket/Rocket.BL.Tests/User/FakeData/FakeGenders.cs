using System.Collections.Generic;
using Bogus;
using Rocket.BL.Common.Models.User;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о поле пользователя.
    /// в моделях хранения данных.
    /// </summary>
    public class FakeGenders
    {
        /// <summary>
        /// Возвращает генератор данных о поле пользователя.
        /// </summary>
        public Faker<Gender> GenderFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных данных о поле пользователя.
        /// </summary>
        public List<Gender> Genders { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о поле пользователя.
        /// </summary>
        /// <param name="gendersCount">Необходимое количество экземпляров полов пользователей, которые необходимо сгенерировать</param>
        public FakeGenders(int gendersCount)
        {
            GenderFaker = new Faker<Gender>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Person.Gender.ToString());

            Genders = GenderFaker.Generate(gendersCount);
        }
    }
}
using Bogus;
using Rocket.DAL.Common.DbModels.User;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о поле пользователя.
    /// в моделях хранения данных.
    /// </summary>
    public class FakeDbGenders
    {
        /// <summary>
        /// Возвращает генератор данных о поле пользователя.
        /// </summary>
        public Faker<DbGender> GenderlFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных данных о поле пользователя.
        /// </summary>
        public List<DbGender> Genders { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о поле пользователя.
        /// </summary>
        /// <param name="gendersCount">Необходимое количество экземпляров полов пользователей, которые необходимо сгенерировать</param>
        public FakeDbGenders(int gendersCount)
        {
            GenderlFaker = new Faker<DbGender>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Person.Gender.ToString());

            Genders = GenderlFaker.Generate(gendersCount);
        }
    }
}
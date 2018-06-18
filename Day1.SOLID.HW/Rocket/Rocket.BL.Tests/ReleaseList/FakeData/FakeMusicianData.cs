using System.Collections.Generic;
using Bogus;
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о музыкальных исполнителях,
    /// в моделях домена
    /// </summary>
    public class FakeMusicianData
    {
        /// <summary>
        /// Возвращает генератор данных о музыкантах
        /// </summary>
        public Faker<Musician> MusicianFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных музыкантов
        /// </summary>
        public List<Musician> Persons { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о музыкантов
        /// </summary>
        /// <param name="personsCount">Необходимое количество сгенерированных музыкантов</param>
        public FakeMusicianData(int personsCount)
        {
            MusicianFaker = new Faker<Musician>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.FullName, f => f.Person.FullName);

            Persons = MusicianFaker.Generate(personsCount);
        }
    }
}
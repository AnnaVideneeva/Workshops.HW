using Bogus;
using Rocket.DAL.Common.DbModels.Parser;
using System.Collections.Generic;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о людях,
    /// в моделях хранения данных
    /// </summary>
    public class FakePersonEntities
    {
        /// <summary>
        /// Возвращает генератор данных о людях
        /// </summary>
        public Faker<PersonEntity> PersonFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных людей
        /// </summary>
        public List<PersonEntity> PersonEntities { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о людях
        /// </summary>
        /// <param name="personsCount">Необходимое количество сгенерированных людей</param>
        public FakePersonEntities(int personsCount, FakePersonTypeEntities personTypes)
        {
            var nameRu = new Bogus.DataSets.Name("ru");
            PersonFaker = new Faker<PersonEntity>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.FullNameRu, f => nameRu.FullName())
                .RuleFor(p => p.FullNameEn, f => f.Person.FullName)
                .RuleFor(p => p.LostfilmPersonalPageUrl, f => f.Internet.Url())
                .RuleFor(p => p.PhotoThumbnailUrl, f => f.Internet.Url())
                .RuleFor(p => p.PersonType, f => f.PickRandom(personTypes.PersonTypeEntities))
                .RuleFor(p => p.ListTvSerias, () => new List<TvSeriasEntity>());

            PersonEntities = PersonFaker.Generate(personsCount);

            foreach (var personEntity in PersonEntities)
            {
                personEntity.PersonTypeCode = personEntity.PersonType.Code;
                personEntity.PersonType.ListPerson.Add(personEntity);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Migrations.InitialDataCreators.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных об адресах пользователей,
    /// в моделях хранения данных.
    /// </summary>
    public class FakeDbAddresses
    {
        /// <summary>
        /// Создает новый экземпляр сгенерированных адресов пользователей.
        /// </summary>
        /// <param name="dbCountries">Коллекция всех стран.</param>
        public FakeDbAddresses(ICollection<DbCountry> dbCountries)
        {
            AddressFaker = new Faker<DbAddress>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.ZipCode, f => f.Address.ZipCode())

                // Выбираем случайным образом страну непосредственно из репозитория (всего в репозитории 251 модель стран).
                .RuleFor(c => c.Country, f => dbCountries.ToArray()[new Random().Next(1, 251)])
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Building, f => f.Address.BuildingNumber())
                .RuleFor(c => c.BuildingBlock, f => f.PickRandomParam(string.Empty, "A", "B", "C", "D", "1", "2", "3", "4", "5"))
                .RuleFor(c => c.Flat, f => f.Address.Random.Number(1, 320).ToString());

            Addresses = AddressFaker.Generate(1);
        }

        /// <summary>
        /// Возвращает генератор данных об адресах пользователей.
        /// </summary>
        public Faker<DbAddress> AddressFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных адресов пользователей.
        /// </summary>
        public List<DbAddress> Addresses { get; }
    }
}
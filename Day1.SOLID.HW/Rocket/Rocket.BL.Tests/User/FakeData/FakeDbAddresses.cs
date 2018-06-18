using Bogus;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Common.DbModels.ReleaseList;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных об адресах пользователей,
    /// в моделях хранения данных
    /// </summary>
    public class FakeDbAddresses
    {
        /// <summary>
        /// Возвращает генератор данных об адресах пользователей
        /// </summary>
        public Faker<DbAddress> AddressFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных адресов пользователей
        /// </summary>
        public List<DbAddress> Addresses { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных адресов пользователей
        /// </summary>
        /// <param name="addressesCount">Необходимое количество адресов пользователей</param>
        public FakeDbAddresses(int addressesCount)
        {
            AddressFaker = new Faker<DbAddress>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.ZipCode, f => f.Address.ZipCode())
                .RuleFor(c => c.Country, f => f.PickRandomParam(new FakeDbCountries(15).Countries.ToArray()))
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Building, f => f.Address.BuildingNumber())
                .RuleFor(c => c.BuildingBlock,
                    f => f.PickRandomParam(string.Empty, "A", "B", "C", "D", "1", "2", "3", "4", "5"))
                .RuleFor(c => c.Flat, f => f.Address.Random.Number(1, 320).ToString());
            Addresses = AddressFaker.Generate(addressesCount);
        }
    }
}
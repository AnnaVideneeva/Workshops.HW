using Bogus;
using Rocket.BL.Common.Models.User;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных об адресах пользователей,
    /// в моделях домена
    /// </summary>
    public class FakeAddresses
    {
        /// <summary>
        /// Возвращает генератор данных об адресах пользователей
        /// </summary>
        public Faker<Address> AddressFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных адресов пользователей
        /// </summary>
        public List<Address> Addresses { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных адресов пользователей
        /// </summary>
        /// <param name="addressesCount">Необходимое количество адресов пользователей</param>
        public FakeAddresses(int addressesCount)
        {
            AddressFaker = new Faker<Address>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.ZipCode, f => f.Address.ZipCode())
                .RuleFor(c => c.Country, f => f.PickRandomParam(new FakeCountries(15).Countries.ToArray()))
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Building, f => f.Address.BuildingNumber())
                .RuleFor(c => c.BuildingBlock,
                    f => f.PickRandomParam(string.Empty, "A", "B", "C", "D", "1", "2", "3", "4", "5"))
                .RuleFor(c => c.Flat, f => f.Address.Random.Number(1, 320).ToString());
            Addresses = AddressFaker.Generate(addressesCount);
        }
    }
}
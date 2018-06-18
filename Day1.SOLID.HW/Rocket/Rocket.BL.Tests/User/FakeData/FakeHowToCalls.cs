using Bogus;
using Rocket.BL.Common.Models.User;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о том, как обращаться к пользователю
    /// в моделях домена
    /// </summary>
    public class FakeHowToCalls
    {
        /// <summary>
        /// Возвращает генератор данных о том, как обращаться к пользователю
        /// </summary>
        public Faker<HowToCall> HowToCallFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных данных о том, как обращаться к пользователю
        /// </summary>
        public List<HowToCall> HowToCalls { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о том, как обращаться к пользователю
        /// </summary>
        /// <param name="countriesCount">Необходимое количество обращений к пользователю, которые необходимо сгенерировать</param>
        public FakeHowToCalls(int howToCallsCount)
        {
            HowToCallFaker = new Faker<HowToCall>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Lorem.Word());

            HowToCalls = HowToCallFaker.Generate(howToCallsCount);
        }
    }
}
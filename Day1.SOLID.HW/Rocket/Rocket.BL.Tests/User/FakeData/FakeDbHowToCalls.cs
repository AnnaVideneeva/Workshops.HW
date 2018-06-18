using Bogus;
using Rocket.DAL.Common.DbModels.User;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о том, как обращаться к пользователю
    /// в моделях домена
    /// </summary>
    public class FakeDbHowToCalls
    {
        /// <summary>
        /// Возвращает генератор данных о том, как обращаться к пользователю
        /// </summary>
        public Faker<DbHowToCall> HowToCallFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных данных о том, как обращаться к пользователю
        /// </summary>
        public List<DbHowToCall> HowToCalls { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о том, как обращаться к пользователю
        /// </summary>
        /// <param name="howToCallsCount">Необходимое количество обращений к пользователю, которые необходимо сгенерировать</param>
        public FakeDbHowToCalls(int howToCallsCount)
        {
            HowToCallFaker = new Faker<DbHowToCall>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Lorem.Word());

            HowToCalls = HowToCallFaker.Generate(howToCallsCount);
        }
    }
}
using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Migrations.InitialDataCreators.User
{
    /// <summary>
    /// Формирует коллекцию первоначальных сведений о том, как необходимо обращаться к пользователю,
    /// для заполнения ими соответствующего репозитация.
    /// </summary>
    public class DbHowToCallCreator
    {
        /// <summary>
        /// Задает коллекцию сведений о том, как надо обращаться к пользователю.
        /// </summary>
        public List<DbHowToCall> Items { get; } = new List<DbHowToCall>()
        {
            new DbHowToCall() { Id = 1, Name = "Mr." },
            new DbHowToCall() { Id = 2, Name = "Ms." }
        };
    }
}

using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Migrations.InitialDataCreators.User
{
    /// <summary>
    /// Формирует коллекцию языков,
    /// для заполнения ими соответствующего репозитация.
    /// </summary>
    public class DbLanguagesCreator
    {
        /// <summary>
        /// Задает коллекцию основных языков.
        /// </summary>
        public List<DbLanguage> Items { get; } = new List<DbLanguage>()
        {
            new DbLanguage() { Id = 1, Name = "Русский" },
            new DbLanguage() { Id = 2, Name = "Английский" },
            new DbLanguage() { Id = 3, Name = "Испанский" },
            new DbLanguage() { Id = 4, Name = "Арабский" },
            new DbLanguage() { Id = 5, Name = "Португальский" },
            new DbLanguage() { Id = 6, Name = "Китайский" },
            new DbLanguage() { Id = 7, Name = "Немецкий" },
            new DbLanguage() { Id = 8, Name = "Французский" },
            new DbLanguage() { Id = 9, Name = "Венгерский" },
            new DbLanguage() { Id = 10, Name = "Шведский" },
            new DbLanguage() { Id = 11, Name = "Итальянский" },
            new DbLanguage() { Id = 12, Name = "Датский" },
            new DbLanguage() { Id = 13, Name = "Ирландский" }
        };
    }
}

using System;
using Bogus;
using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.Identity;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных разрешений ролей пользователя,
    /// в моделях хранения данных
    /// </summary>
    public class FakeDbPermissions
    {
        /// <summary>
        /// Возвращает генератор разрешений ролей пользователя
        /// </summary>
        public Faker<DbPermission> PermissionFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных разрешений ролей пользователя
        /// </summary>
        public List<DbPermission> Permissions { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о разрешенийях ролей пользователя
        /// </summary>
        /// <param name="permissionsCount">Необходимое количество сгенерированных разрешений ролей пользоватоля</param>
        public FakeDbPermissions(int permissionsCount)
        {
            PermissionFaker = new Faker<DbPermission>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Description, f => f.Lorem.Sentences(new Random().Next(1, 5)))
                .RuleFor(c => c.ValueName, f => f.Lorem.Letter(5));

            Permissions = PermissionFaker.Generate(permissionsCount);
        }
    }
}
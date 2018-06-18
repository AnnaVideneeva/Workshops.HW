using System;
using Bogus;
using Rocket.BL.Common.Models.UserRoles;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных разрешений ролей пользователя,
    /// в моделях домена
    /// </summary>
    public class FakePermissions
    {
        /// <summary>
        /// Возвращает генератор разрешений ролей пользователя
        /// </summary>
        public Faker<Permission> PermissionFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных разрешений ролей пользователя
        /// </summary>
        public List<Permission> Permissions { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о разрешенийях ролей пользователя
        /// </summary>
        /// <param name="permissionsCount">Необходимое количество сгенерированных разрешений ролей пользоватоля</param>
        public FakePermissions(int permissionsCount)
        {
            PermissionFaker = new Faker<Permission>()
                .RuleFor(c => c.PermissionId, f => f.IndexFaker)
                .RuleFor(c => c.Description, f => f.Lorem.Sentences(new Random().Next(1, 5)))
                .RuleFor(c => c.ValueName, f => f.Lorem.Letter(5));

            Permissions = PermissionFaker.Generate(permissionsCount);
        }
    }
}
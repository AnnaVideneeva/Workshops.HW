using System;
using Bogus;
using Rocket.BL.Common.Models.UserRoles;
using System.Collections.Generic;

namespace Rocket.BL.Tests.User.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных ролей пользователя,
    /// в моделях домена
    /// </summary>
    public class FakeRoles
    {
        /// <summary>
        /// Возвращает генератор ролей пользователя
        /// </summary>
        public Faker<Role> RoleFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных ролей пользователя
        /// </summary>
        public List<Role> Roles { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о ролях пользователя
        /// </summary>
        /// <param name="rolesCount">Необходимое количество сгенерированных ролей пользоватоля</param>
        public FakeRoles(int rolesCount)
        {
            RoleFaker = new Faker<Role>()
                //.RuleFor(c => c.RoleId, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Lorem.Word())
                .RuleFor(c => c.Permissions, f => { return new FakePermissions(new Random().Next(1, 5)).Permissions; });

            Roles = RoleFaker.Generate(rolesCount);
        }
    }
}
//using System;
//using System.Collections.Generic;
//using Bogus;
//using Rocket.DAL.Common.DbModels.User;

//namespace Rocket.BL.Tests.User.FakeData
//{
//    /// <summary>
//    /// Представляет набор сгенерированных данных о пользователях,
//    /// в моделях хранинения данных.
//    /// </summary>
//    public class FakeDbUsers
//    {
//        /// <summary>
//        /// Возвращает генератор данных о пользователях
//        /// </summary>
//        public Faker<DbUser> UserFaker { get; }

//        /// <summary>
//        /// Возвращает коллекцию сгенерированных пользователей
//        /// </summary>
//        public List<DbUser> Users { get; }

//        /// <summary>
//        /// Создает новый экземпляр сгенерированных данных о пользователях
//        /// </summary>
//        /// <param name="userCount">Возвращает количество генерируемых пользователей</param>
//        /// <param name="isFirstNameNullOrEmpty">Возвращает true, если имя пользователя не указано</param>
//        /// <param name="isLastNameNullOrEmpty">Возвращает true, если фамилия пользователя не указана</param>667.южж
//        /// <param name="isLoginNullOrEmpty">Возвращает true, если логин не указан</param>
//        /// <param name="isPasswordNullOrEmpty">Возвращает true, если пароль не указан</param>
//        /// <param name="minLoginLenght">Задает минимальное количество символов в логине</param>
//        /// <param name="minPasswordLenght">Задает минимальное количество символов в пароле</param>
//        public FakeDbUsers(int usersCount, bool isFirstNameNullOrEmpty, bool isLastNameNullOrEmpty,
//            bool isLoginNullOrEmpty, bool isPasswordNullOrEmpty, int minLoginLenght, int minPasswordLenght)
//        {
//            var result = new Faker<DbUser>()
//                .RuleFor(p => p.Id, f => f.IndexFaker)
//                .RuleFor(p => p.AccountStatus,
//                    f => f.PickRandomParam(new FakeDbAccountStatuses(5).AccountStatuses.ToArray()))
//                .RuleFor(p => p.AccountLevel,
//                    f => f.PickRandomParam(new FakeDbAccountLevels(5).AccountLevels.ToArray()))
//                .RuleFor(p => p.Roles, f => new FakeDbRoles(new Random().Next(1, 5)).Roles)
//                .RuleFor(p => p.FirstName, f => isFirstNameNullOrEmpty ? string.Empty : f.Person.FirstName)
//                .RuleFor(p => p.LastName, f => isLastNameNullOrEmpty ? string.Empty : f.Person.LastName)
//                .RuleFor(p => p.Login,
//                    f => isLoginNullOrEmpty ? string.Empty : f.Lorem.Letter(minLoginLenght))
//                .RuleFor(p => p.Password,
//                    f => isPasswordNullOrEmpty ? string.Empty : f.Lorem.Letter(minPasswordLenght))
//                .RuleFor(p => p.UserDetail, f => new FakeDbUserDetails(1).UserDetails[0]);
//            ;

//            Users = result.Generate(usersCount);
//        }
//    }
//}
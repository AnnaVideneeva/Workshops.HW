//using AutoMapper;
//using FluentAssertions;
//using Moq;
//using NUnit.Framework;
//using Rocket.BL.Services.User;
//using Rocket.BL.Tests.User.FakeData;
//using Rocket.DAL.Common.DbModels.User;
//using Rocket.DAL.Common.Repositories.User;
//using Rocket.DAL.Common.UoW;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;

//namespace Rocket.BL.Tests.User
//{
//    /// <summary>
//    /// Unit-тесты для сервиса <see cref="UserValidateService"/>
//    /// </summary>
//    [TestFixture]
//    public class UserManagementServiceTest
//    {
//        private const int UsersCount = 300;
//        private UserManagementService _userManagementService;
//        private FakeDbUsers _fakeDbUsers;

//        /// <summary>
//        /// Осуществляет настройки
//        /// </summary>
//        [OneTimeSetUp]
//        public void SetUp()
//        {
//            Mapper.Reset();
//            Mapper.Initialize(cfg => { cfg.AddProfiles("Rocket.BL.Common"); });

//            _fakeDbUsers = new FakeDbUsers(UsersCount, false, false, false, false, 5, 5);

//            var moq = new Mock<IDbUserRepository>();
//            moq.Setup(mock => mock.Get(It.IsAny<Expression<Func<DbUser, bool>>>(), null, ""))
//                .Returns((Expression<Func<DbUser, bool>> filter,
//                    Func<IQueryable<DbUser>, IOrderedQueryable<DbUser>> orderBy,
//                    string includeProperties) => _fakeDbUsers.Users.Where(filter.Compile()));
//            moq.Setup(mock => mock.ItemsCount(It.IsAny<Expression<Func<DbUser, bool>>>()))
//                .Returns((Expression<Func<DbUser, bool>> filter) => _fakeDbUsers.Users.Where(filter.Compile()).Count());
//            moq.Setup(mock => mock.GetById(It.IsAny<int>()))
//                .Returns((int id) => _fakeDbUsers.Users.Find(f => f.Id == id));
//            moq.Setup(mock => mock.Insert(It.IsAny<DbUser>()))
//                .Callback((DbUser f) => _fakeDbUsers.Users.Add(f));
//            moq.Setup(mock => mock.Update(It.IsAny<DbUser>()))
//                .Callback((DbUser f) => _fakeDbUsers.Users.Find(d => d.Id == f.Id).Login = f.Login);
//            moq.Setup(mock => mock.Delete(It.IsAny<int>()))
//                .Callback((int id) => _fakeDbUsers.Users
//                    .Remove(_fakeDbUsers.Users.Find(f => f.Id == id)));

//            var mockDbUserUnitOfWork = new Mock<IUnitOfWork>();
//            mockDbUserUnitOfWork.Setup(mock => mock.UserRepository)
//                .Returns(() => moq.Object);

//            _userManagementService = new UserManagementService(mockDbUserUnitOfWork.Object);
//        }

//        /// <summary>
//        /// Тест метода получения экземпляров пользователей
//        /// выбранной страницы пейджинга. Выбрана может быть любая страница.
//        /// </summary>
//        [Test, Order(1)]
//        public void GetExistedUsersPageTest([Random(1, 18, 5)]int pageNumber)
//        {
//            const int pagesize = 16;

//            // Arrange
//            var dbUsers = _fakeDbUsers.Users;

//            var usersPageIndexes = new List<int>();

//            var startUserIndexInPage = pagesize * (pageNumber - 1);

//            var finishUserIndexInPage = startUserIndexInPage + pagesize - 1;

//            for (var i = startUserIndexInPage; i <= finishUserIndexInPage; i++)
//            {
//                usersPageIndexes.Add(i);
//            }

//            List<DbUser> dbUsersPage;
//            dbUsersPage = usersPageIndexes.Select(usersPageIndex => dbUsers[usersPageIndex]).ToList();

//            var expectedUsersPage = dbUsersPage.Select(Mapper.Map<Common.Models.User.User>).ToList();

//            // Act
//            var actualUsersPage = _userManagementService.GetUsersPage(pageSize: pagesize, pageNumber: pageNumber).ToList();

//            // Assert
//            expectedUsersPage.Should().BeEquivalentTo(actualUsersPage,
//                options => options.ExcludingMissingMembers());
//        }

//        /// <summary>
//        /// Тест метода получения экземпляров пользователей
//        /// выбранной страницы пейджинга. Выбрана последняя страница.
//        /// </summary>
//        [Test, Order(1)]
//        public void GetExistedUsersLastPageTest()
//        {
//            const int pagesize = 16;
//            const int pageNumber = 19;

//            // Arrange
//            var dbUsers = _fakeDbUsers.Users;

//            var usersPageIndexes = new List<int>();

//            var startUserIndexInPage = pagesize * (pageNumber - 1);

//            var finishUserIndexInPage = startUserIndexInPage + UsersCount % pagesize - 1;

//            for (var i = startUserIndexInPage; i <= finishUserIndexInPage; i++)
//            {
//                usersPageIndexes.Add(i);
//            }

//            var dbUsersPage = usersPageIndexes.Select(usersPageIndex => dbUsers[usersPageIndex]).ToList();

//            var expectedUsersPage = dbUsersPage.Select(Mapper.Map<Common.Models.User.User>).ToList();

//            // Act
//            var actualUsersPage = _userManagementService.GetUsersPage(pageSize: pagesize, pageNumber: pageNumber).ToList();

//            // Assert
//            expectedUsersPage.Should().BeEquivalentTo(actualUsersPage,
//                options => options.ExcludingMissingMembers());
//        }

//        /// <summary>
//        /// Тест метода получения экземпляров пользователей
//        /// выбранной страницы пейджинга. Номер страницы отрицательный.
//        /// </summary>
//        [Test, Order(1)]
//        public void GetNotExistedUsersPageWithNegativePageNumbersTest([Random(-100500, -1, 5)] int pageNumber)
//        {
//            const int pagesize = 16;

//            // Act
//            ICollection<Common.Models.User.User> actualUsersPage = _userManagementService.GetUsersPage(pageSize: pagesize, pageNumber: pageNumber);

//            // Assert
//            actualUsersPage.Should().BeNull();
//        }

//        /// <summary>
//        /// Тест метода получения экземпляров пользователей
//        /// выбранной страницы пейджинга. Номер страницы больше общего числа страниц.
//        /// </summary>
//        [Test, Order(1)]
//        public void GetNotExistedUsersPageWithValueIfPageNumbersMoreThanTotalUsersPagesTest([Random(UsersCount, UsersCount + 100500, 5)]int pageNumber)
//        {
//            const int pagesize = 16;

//            // Act
//            ICollection<Common.Models.User.User> actualUsersPage = _userManagementService.GetUsersPage(pageSize: pagesize, pageNumber: pageNumber);

//            // Assert
//            actualUsersPage.Should().BeNull();
//        }

//        /// <summary>
//        /// Тест метода получения экземпляров пользователей
//        /// ввыбранной страницы пейджинга из пустого репозитария.
//        /// </summary>
//        [Test, Order(5)]
//        public void GetNotExistedUsersPageFromEmptyRepositoryTest([Random(1, 18, 5)]int pageNumber)
//        {
//            const int pagesize = 16;

//            // Arrange
//            _fakeDbUsers.Users.Clear();

//            // Act
//            ICollection<Common.Models.User.User> actualUsersPage = _userManagementService.GetUsersPage(pageSize: pagesize, pageNumber: pageNumber);

//            // Assert
//            actualUsersPage.Should().BeNull();
//        }

//        /// <summary>
//        /// Тест метода получения всех экземпляров пользователей
//        /// в пустом репозитарии.
//        /// </summary>
//        [Test, Order(5)]
//        public void GetAllUsersFromEmptyRepositoryTest()
//        {
//            // Arrange
//            _fakeDbUsers.Users.Clear();

//            // Act
//            var actualUsers = _userManagementService.GetAllUsers();

//            // Assert
//            actualUsers.Should().BeNull();
//        }

//        /// <summary>
//        /// Тест метода получения всех экземпляров пользователей
//        /// в не пустом репозитарии.
//        /// </summary>
//        [Test, Order(1)]
//        public void GetAllExistedUsersTest()
//        {
//            // Arrange
//            var expectedUsers = _fakeDbUsers.Users;

//            // Act
//            var actualUsers = _userManagementService.GetAllUsers().ToList();

//            // Assert
//            foreach (var expectedUser in expectedUsers)
//            {
//                var i = expectedUser.Id;

//                expectedUsers[i].Login.Should().Be(actualUsers[i].Login);
//                expectedUsers[i].FirstName.Should().Be(actualUsers[i].FirstName);
//                expectedUsers[i].LastName.Should().Be(actualUsers[i].LastName);
//                expectedUsers[i].Password.Should().Be(actualUsers[i].Password);
//            }

//            //expectedUsers.Should().BeEquivalentTo(actualUsers,
//            //    options => options.ExcludingMissingMembers());

//            expectedUsers.Count.Should().Be(actualUsers.Count);
//        }

//        /// <summary>
//        /// Тест метода получения экземпляра пользователя по заданному идентификатору.
//        /// пользователь с передаваемым идентификатором существует
//        /// </summary>
//        /// <param name="id">Идентификатор пользователя</param>
//        [Test, Order(1)]
//        public void GetExistedUserTest([Random(0, UsersCount - 1, 5)] int id)
//        {
//            // Arrange
//            var expectedUser = _fakeDbUsers.Users.Find(f => f.Id == id);

//            // Act
//            var actualUser = _userManagementService.GetUser(id);

//            // Assert
//            actualUser.UserDetail.PhoneNumbers.Should().BeEquivalentTo(expectedUser.UserDetail.PhoneNumbers,
//                options => options.ExcludingMissingMembers());
//            actualUser.UserDetail.EMailAddresses.Should().BeEquivalentTo(expectedUser.UserDetail.EMailAddresses,
//                options => options.ExcludingMissingMembers());
//            actualUser.Login.Should().BeEquivalentTo(expectedUser.Login);
//            actualUser.FirstName.Should().BeEquivalentTo(expectedUser.FirstName);
//            actualUser.LastName.Should().BeEquivalentTo(expectedUser.LastName);
//        }

//        /// <summary>
//        /// Тест метода получения экземпляра пользователя по заданному идентификатору.
//        /// пользователь с передаваемым идентификатором не существует
//        /// </summary>
//        /// <param name="id">Идентификатор пользователя</param>
//        [Test, Order(1)]
//        public void GetNotExistedUserTest([Random(UsersCount, UsersCount + 300, 5)]
//            int id)
//        {
//            var actualUser = _userManagementService.GetUser(id);

//            actualUser.Should().BeNull();
//        }

//        /// <summary>
//        /// Тест метода добавления пользователя в хранилище данных
//        /// </summary>
//        [Test, Repeat(5), Order(2)]
//        public void AddUserTest()
//        {
//            // Arrange
//            var user = new FakeUsers(1, false, false, false, false, 5, 5).Users[0];
//            user.Id = _fakeDbUsers.Users.Last().Id + 1;

//            // Act
//            var actualId = _userManagementService.AddUser(user);

//            var actualUser = _userManagementService.GetUser(actualId);

//            // Assert
//            actualUser.UserDetail.EMailAddresses.Should().BeEquivalentTo(user.UserDetail.EMailAddresses,
//                options => options.ExcludingMissingMembers());
//            actualUser.Login.Should().BeEquivalentTo(user.Login);
//            actualUser.FirstName.Should().BeEquivalentTo(user.FirstName);
//            actualUser.LastName.Should().BeEquivalentTo(user.LastName);
//        }

//        /// <summary>
//        /// Тест метода добавления пользователя в хранилище данных
//        /// </summary>
//        [Test, Repeat(5), Order(2)]
//        public void AddUserIntegratedTest()
//        {
//            //IUnitOfWork _unitOfWork;

//            //// Arrange
//            //var user = new FakeUsers(1, false, false, false, false, 5, 5).Users[0];
//            //var userManagementService = new UserManagementService(_unitOfWork);
//            //user.Id = _fakeDbUsers.Users.Last().Id + 1;

//            //// Act
//            //var actualId = _userManagementService.AddUser(user);

//            //var actualUser = _userManagementService.GetUser(actualId);

//            //// Assert
//            //actualUser.UserDetail.EMailAddresses.Should().BeEquivalentTo(user.UserDetail.EMailAddresses,
//            //    options => options.ExcludingMissingMembers());
//            //actualUser.Login.Should().BeEquivalentTo(user.Login);
//            //actualUser.FirstName.Should().BeEquivalentTo(user.FirstName);
//            //actualUser.LastName.Should().BeEquivalentTo(user.LastName);
//        }

//        /// <summary>
//        /// Тест метода обновления данных о пользователе
//        /// </summary>
//        /// <param name="id">Идентификатор пользователя для обновления</param>
//        [Test, Order(2)]
//        public void UpdateUserTest([Random(0, UsersCount - 1, 5)] int id)
//        {
//            // Arrange
//            var user = _userManagementService.GetUser(id);
//            user.Login = new Bogus.Faker().Internet.UserName();

//            // Act
//            _userManagementService.UpdateUser(user);
//            var actualUser = _fakeDbUsers.Users.Find(f => f.Id == id);

//            // Assert
//            actualUser.Login.Should().Be(user.Login);
//        }

//        /// <summary>
//        /// Тест метода удаления пользователя из хранилища данных
//        /// </summary>
//        /// <param name="id">Идентификатор пользователя для удаления</param>
//        [Test, Order(3)]
//        public void DeleteUserTest([Random(0, UsersCount - 1, 5)] int id)
//        {
//            // Arrange
//            _userManagementService.DeleteUser(id);

//            // Act
//            var actualUser = _fakeDbUsers.Users.Find(user => user.Id == id);

//            // Assert
//            actualUser.Should().BeNull();
//        }

//        /// <summary>
//        /// Тест метода проверки наличия пользователя в хранилище данных.
//        /// пользователь существует
//        /// </summary>
//        /// <param name="id">Идентификатор пользователя для поиска</param>
//        [Test, Order(2)]
//        public void UserExistsTest([Random(0, UsersCount - 1, 5)] int id)
//        {
//            // Arrange
//            var loginToFind = _fakeDbUsers.Users.Find(dbf => dbf.Id == id).Login;

//            // Act
//            var actual = _userManagementService
//                .UserExists(f => f.Login == loginToFind);

//            // Assert
//            actual.Should().BeTrue();
//        }

//        /// <summary>
//        /// Тест метода проверки наличия пользователя в хранилище данных.
//        /// пользователь не существует
//        /// </summary>
//        /// <param name="login">Логин пользователя для поиска</param>
//        [Test, Order(2)]
//        public void UserNotExistsTest([Values("shameonyou", "qwer", "", "befastandclearver", "strangelogin")]
//            string login)
//        {
//            var actual = _userManagementService
//                .UserExists(f => f.Login == login);

//            actual.Should().BeFalse();
//        }
//    }
//}
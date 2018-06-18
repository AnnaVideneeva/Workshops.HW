using AutoMapper;
using NUnit.Framework;
using Rocket.BL.Services.User;
using FluentAssertions;
using Rocket.BL.Tests.User.FakeData;

namespace Rocket.BL.Tests.User
{
    /// <summary>
    /// Unit-тесты для сервиса <see cref="UserValidateService"/>
    /// </summary>
    [TestFixture]
    public class UserValidateServiceTest
    {
        private UserValidateService _userValidateService;

        /// <summary>
        /// Осуществляет настройки
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            _userValidateService = new UserValidateService();
        }

        /// <summary>
        /// Метод UserValidateOnAddition сервиса UserValidateService должен возвращать
        /// false, если имя пользователя не введено.
        /// </summary>
        [Test, Order(1)]
        public void UserValidateServiceFirstNameOfUserIsNullOrEmptyTest()
        {
            // Arrange
            var fakerNewUsers = new FakeUsers(
                usersCount: 1,
                isFirstNameNullOrEmpty: true,
                isLastNameNullOrEmpty: false,
                isLoginNullOrEmpty: false,
                isPasswordNullOrEmpty: false,
                minLoginLenght: 5,
                minPasswordLenght: 5);

            // Act
            UserValidateService userValidateService = new UserValidateService();
            var resultUserValidationBeforRegistration =
                userValidateService.UserValidateOnAddition(fakerNewUsers.Users[0]);


            // Assert
            resultUserValidationBeforRegistration.Should().BeFalse();
        }

        /// <summary>
        /// Метод UserValidateOnAddition сервиса UserValidateService должен возвращать
        /// false, если фамилия пользователя не введено.
        /// </summary>
        [Test, Order(2)]
        public void UserValidateServiceLastNameOfUserIsNullOrEmptyTest()
        {
            // Arrange
            var fakerNewUsers = new FakeUsers(
                usersCount: 1,
                isFirstNameNullOrEmpty: false,
                isLastNameNullOrEmpty: true,
                isLoginNullOrEmpty: false,
                isPasswordNullOrEmpty: false,
                minLoginLenght: 5,
                minPasswordLenght: 5);

            // Act
            var resultUserValidationBeforRegistration =
                _userValidateService.UserValidateOnAddition(fakerNewUsers.Users[0]);

            // Assert
            resultUserValidationBeforRegistration.Should().BeFalse();
        }

        /// <summary>
        /// Метод UserValidateOnAddition сервиса UserValidateService должен возвращать
        /// false, если логин пользователя не введен.
        /// </summary>
        [Test, Order(3)]
        public void UserValidateServiceLoginOfUserIsNullOrEmptyTest()
        {
            // Arrange
            var fakerNewUsers = new FakeUsers(
                usersCount: 1,
                isFirstNameNullOrEmpty: false,
                isLastNameNullOrEmpty: false,
                isLoginNullOrEmpty: true,
                isPasswordNullOrEmpty: false,
                minLoginLenght: 5,
                minPasswordLenght: 5);
            var userValidateService = new UserValidateService();

            // Act
            var resultUserValidationBeforRegistration =
                _userValidateService.UserValidateOnAddition(fakerNewUsers.Users[0]);

            // Assert
            resultUserValidationBeforRegistration.Should().BeFalse();
        }

        /// <summary>
        /// Метод UserValidateOnAddition сервиса UserValidateService должен возвращать
        /// false, если пароль пользователя не введен.
        /// </summary>
        [Test, Order(4)]
        public void UserValidateServicePasswordOfUserIsNullOrEmptyTest()
        {
            // Arrange
            var fakerNewUsers = new FakeUsers(
                usersCount: 1,
                isFirstNameNullOrEmpty: false,
                isLastNameNullOrEmpty: false,
                isLoginNullOrEmpty: false,
                isPasswordNullOrEmpty: true,
                minLoginLenght: 5,
                minPasswordLenght: 5);

            // Act
            var resultUserValidationBeforRegistration =
                _userValidateService.UserValidateOnAddition(fakerNewUsers.Users[0]);

            // Assert
            resultUserValidationBeforRegistration.Should().BeFalse();
        }

        /// <summary>
        /// Метод UserValidateOnAddition сервиса UserValidateService должен возвращать
        /// false, если пароль пользователя менее 5 символов.
        /// </summary>
        [Test, Order(5)]
        public void UserValidateServicePasswordOfUserLenthLessThanEstablishedTest()
        {
            // Arrange
            var fakerNewUsers = new FakeUsers(
                usersCount: 1,
                isFirstNameNullOrEmpty: false,
                isLastNameNullOrEmpty: false,
                isLoginNullOrEmpty: false,
                isPasswordNullOrEmpty: false,
                minLoginLenght: 4,
                minPasswordLenght: 5);

            // Act
            var resultUserValidationBeforRegistration =
                _userValidateService.UserValidateOnAddition(fakerNewUsers.Users[0]);

            // Assert
            resultUserValidationBeforRegistration.Should().BeFalse();
        }

        /// <summary>
        /// Метод UserValidateOnAddition сервиса UserValidateService должен возвращать
        /// false, если логин пользователя менее 5 символов.
        /// </summary>
        [Test, Order(6)]
        public void UserValidateServicLoginOfUserLenthLessThanEstablishedTest()
        {
            // Arrange
            var fakerNewUsers = new FakeUsers(
                usersCount: 1,
                isFirstNameNullOrEmpty: false,
                isLastNameNullOrEmpty: false,
                isLoginNullOrEmpty: false,
                isPasswordNullOrEmpty: false,
                minLoginLenght: 4,
                minPasswordLenght: 5);

            // Act
            var resultUserValidationBeforRegistration =
                _userValidateService.UserValidateOnAddition(fakerNewUsers.Users[0]);

            // Assert
            resultUserValidationBeforRegistration.Should().BeFalse();
        }

        /// <summary>
        /// Метод UserValidateOnAddition сервиса UserValidateService должен возвращать
        /// true, если длина логина и пользователя больше или равно 5 символов. 
        /// Имя и фамилия пользователя не являются пустыми строками.
        /// </summary>
        [Test, Order(7)]
        public void UserValidateServicAllConditionsMetTest()
        {
            // Arrange
            var fakerNewUsers = new FakeUsers(
                usersCount: 1,
                isFirstNameNullOrEmpty: false,
                isLastNameNullOrEmpty: false,
                isLoginNullOrEmpty: false,
                isPasswordNullOrEmpty: false,
                minLoginLenght: 5,
                minPasswordLenght: 5);

            // Act
            var resultUserValidationBeforRegistration =
                _userValidateService.UserValidateOnAddition(fakerNewUsers.Users[0]);

            // Assert
            resultUserValidationBeforRegistration.Should().BeTrue();
        }
    }
}
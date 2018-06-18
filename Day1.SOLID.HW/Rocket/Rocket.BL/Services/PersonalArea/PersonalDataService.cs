using AutoMapper;
using FluentValidation;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.BL.Common.Services.PersonalArea;
using Rocket.BL.Properties;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Common.UoW;
using Rocket.DAL.Identity;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rocket.BL.Services.PersonalArea
{
    public class PersonalDataService : BaseService, IPersonalData
    {
        private readonly IValidator _validator;
        private readonly RocketUserManager _userManager;

        public PersonalDataService(IUnitOfWork unitOfWork, IValidator<Common.Models.User.User> validator, RocketUserManager usermanager) : base(unitOfWork)
        {
            _validator = validator;
            _userManager = usermanager;
        }

        /// <summary>
        /// Получение пользователя по Id.
        /// </summary>
        /// <param name="id">Id пользователя.</param>
        /// <returns>Модель авторизованного пользователя.</returns>
        public UserProfile GetUserData(string id)
        {
            return Mapper.Map<UserProfile>(_unitOfWork.UserAuthorisedRepository.Get(
                    f => f.DbUser_Id == id,
                    includeProperties: $"{nameof(DbUser)}")
                    ?.FirstOrDefault());
        }

        /// <summary>
        /// Смена пароля.
        /// </summary>
        /// <param name="id">Id пользователя, инициировавшего смену пароля.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <param name="newPasswordConfirm">Подтверждение пароля.</param>
        public void ChangePasswordData(string id, string newPassword, string newPasswordConfirm)
        {
            if (!PasswordValidate(newPassword, newPasswordConfirm))
            {
                throw new ValidationException(Resources.UserWrongPassword);
            }

            var user = _unitOfWork.UserRepository.GetById(id) ?? throw new ValidationException(Resources.InvalidUserId);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(newPassword);
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Смена персональных данных.
        /// </summary>
        /// <param name="id">Id пользователя, инициировавшего смену личных данных.</param>
        /// <param name="firstName">Имя пользователя.</param>
        /// <param name="lastName">Фамилия пользователя.</param>
        /// <param name="avatar">Аватар пользователя.</param>
        public void ChangePersonalData(string id, string firstName, string lastName, string avatar)
        {
            var user = _unitOfWork.UserRepository.Get(
                        f => f.Id == id,
                        includeProperties: $"{nameof(DbUserProfile)}")
                        ?.FirstOrDefault() ?? throw new ValidationException(Resources.InvalidUserId);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.DbUserProfile.Avatar = avatar;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Приватный метод для проверки валидности пароля.
        /// </summary>
        /// <param name="password">Новый пароль.</param>
        /// <param name="passwordConfirm">Подтверждение пароля.</param>
        /// <returns>True - если пароль прошел валидацию, false - если не прошел.</returns>
        private bool PasswordValidate(string password, string passwordConfirm)
        {
            var pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$";
            return Regex.IsMatch(password, pattern) && password == passwordConfirm;
        }
    }
}
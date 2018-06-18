using System.Linq;
using AutoMapper;
using Rocket.BL.Common.Models.User;
using Rocket.BL.Common.Services.User;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Common.UoW;

namespace Rocket.BL.Services.User
{
    /// <summary>
    /// Представляет сервис для работы с уровнем пользователя (обычный, премиум).
    /// </summary>
    public class UserAccountStatusService : BaseService, IUserAccountStatusService
    {
        /// <summary>
        /// Создает новый экземпляр <see cref="UserManagementService"/>
        /// с заданным unit of work.
        /// </summary>
        /// <param name="unitOfWork">Экземпляр unit of work.</param>
        public UserAccountStatusService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        /// <summary>
        /// Получает уровень аккаунта пользователя с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Уровень аккаунта пользователя.</returns>
        public AccountStatus GetUserAccountStatus(string id)
        {
            var isUserExist = _unitOfWork.UserRepository.Get(u => u.Id == id)
                .FirstOrDefault() != null;

            // Проверка на наличие пользователя в хранилище.
            if (!isUserExist)
            {
                return null;
            }

            var user = Mapper.Map<Rocket.BL.Common.Models.User.User>(
                _unitOfWork.UserRepository.GetById(id));

            return user.AccountStatus;
        }

        /// <summary>
        /// Задает значение уровня аккаунта пользователя с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="accountStatus">Задаваемый уровень аккаунта.</param>
        public void SetUserAccountStatus(string id, AccountStatus accountStatus)
        {
            var isUserExist = _unitOfWork.UserRepository.Get(u => u.Id == id)
                                  .FirstOrDefault() != null;

            // Проверка на наличие пользователя в хранилище.
            if (!isUserExist)
            {
                return;
            }

            var user = Mapper.Map<Rocket.BL.Common.Models.User.User>(
                _unitOfWork.UserRepository.GetById(id));

            user.AccountStatus = accountStatus;

            var dbUser = Mapper.Map<DbUser>(user);
            _unitOfWork.UserRepository.Update(dbUser);
            _unitOfWork.SaveChanges();
        }

        public AccountStatus GetUserAccountStatus(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SetUserAccountStatus(int id, AccountStatus accountStatus)
        {
            throw new System.NotImplementedException();
        }
    }
}
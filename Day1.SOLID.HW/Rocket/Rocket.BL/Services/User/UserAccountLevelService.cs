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
    public class UserAccountLevelService : BaseService, IUserAccountLevelService
    {
        /// <summary>
        /// Создает новый экземпляр <see cref="UserManagementService"/>
        /// с заданным unit of work.
        /// </summary>
        /// <param name="unitOfWork">Экземпляр unit of work.</param>
        public UserAccountLevelService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        /// <summary>
        /// Получает уровень аккаунта пользователя с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Уровень аккаунта пользователя.</returns>
        public AccountLevel GetUserAccountLevel(int id)
        {
            var isUserExist = _unitOfWork.UserRepository.Get(u => u.Id == id.ToString())
                .FirstOrDefault() != null;

            // Проверка на наличие пользователя в хранилище.
            if (!isUserExist)
            {
                return null;
            }

            var user = Mapper.Map<Rocket.BL.Common.Models.User.User>(
                _unitOfWork.UserRepository.GetById(id));

            return user.AccountLevel;
        }

        ///// <summary>
        ///// Задает значение уровня аккаунта пользователя с заданным идентификатором.
        ///// </summary>
        ///// <param name="id">Идентификатор пользователя.</param>
        ///// <param name="accountLevel">Задаваемый уровень аккаунта.</param>
        public void SetUserAccountLevel(int id, AccountLevel accountLevel)
        {
            var isUserExist = _unitOfWork.UserRepository.Get(u => u.Id == id.ToString())
                                  .FirstOrDefault() != null;

            // Проверка на наличие пользователя в хранилище.
            if (!isUserExist)
            {
                return;
            }

            var user = Mapper.Map<Rocket.BL.Common.Models.User.User>(
                _unitOfWork.UserRepository.GetById(id));

            user.AccountLevel = accountLevel;

            var dbUser = Mapper.Map<DbUser>(user);
            _unitOfWork.UserRepository.Update(dbUser);
            _unitOfWork.SaveChanges();
        }
    }
}
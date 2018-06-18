using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using Rocket.BL.Common.Models.User;
using Rocket.BL.Common.Services.User;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Common.UoW;
using Rocket.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Rocket.BL.Services.User
{
    /// <summary>
    /// Представляет сервис для работы с пользователями
    /// в хранилище данных.
    /// </summary>
    public class UserManagementService : BaseService, IUserManagementService
    {
        private readonly RocketUserManager _usermanager;
        private readonly IUserAccountLevelService _userAccountLevelService;

        /// <summary>
        /// Создает новый экземпляр <see cref="UserManagementService"/>
        /// с заданным unit of work.
        /// </summary>
        /// <param name="unitOfWork"> uow </param>
        /// <param name="usermanager"> manager </param>
        public UserManagementService(IUnitOfWork unitOfWork, RocketUserManager usermanager, IUserAccountLevelService userAccountLevelService)
            : base(unitOfWork)
        {

            _usermanager = usermanager;
            _userAccountLevelService = userAccountLevelService;
        }
        /// <summary>
        /// Возвращает всех пользователей
        /// из хранилища данных.
        /// </summary>
        /// <returns>Коллекцию всех экземпляров пользователей.</returns>
        public ICollection<Common.Models.User.User> GetAllUsers()
        {
            return _usermanager.Users.ProjectTo<Common.Models.User.User>().ToArray();
        }

        /// <summary>
        /// Возвращает пользователей
        /// из хранилища данных для пейджинга.
        /// </summary>
        /// <param name="pageSize">Количество сведений о пользователях, выводимых на страницу.</param>
        /// <param name="pageNumber">Номер выводимой страницы со сведениями о пользователях.</param>
        /// <returns>Коллекция экземпляров пользователей для пейджинга.</returns>
        public ICollection<Common.Models.User.User> GetUsersPage(int pageSize, int pageNumber)
        {
            return _usermanager.Users.OrderBy(user => user.Id).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<Common.Models.User.User>()
                .ToArray();
        }

        /// <summary>
        /// Возвращает пользователя с заданным идентификатором из хранилища данных.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Экземпляр пользователя.</returns>
        public async Task<Common.Models.User.User> GetUser(string id)
        {
            var user = await _usermanager.FindByIdAsync(id).ConfigureAwait(false);

            return Mapper.Map<Common.Models.User.User>(user);
        }

        /// <summary>
        /// Добавляет заданного пользователя в хранилище данных
        /// и возвращает идентификатор добавленного пользователя.
        /// </summary>
        /// <param name="user">Экземпляр пользователя для добавления.</param>
        /// <returns>Идентификатор пользователя.</returns>
        public async Task<IdentityResult> AddUser(Common.Models.User.User user)
        {
            //user.AccountLevel = _userAccountLevelService.GetUserAccountLevel(1);
            var dbUser = Mapper.Map<DbUser>(user);
            dbUser.Id = Guid.NewGuid().ToString();

            var DbUserProfile = new DbUserProfile()
            {
                Email = new Collection<DbEmail>()
                    {
                        new DbEmail()
                        {
                            Name = "emptyEmail",
                        }
                    },
            };

            dbUser.DbUserProfile = DbUserProfile;

            dbUser.Email = "emptyEmail";
            dbUser.PhoneNumber = "emptyPhoneNumber";
            dbUser.TwoFactorEnabled = false;
            dbUser.LockoutEnabled = false;
            dbUser.AccessFailedCount = 0;

            var result = await _usermanager.CreateAsync(dbUser)
                .ConfigureAwait(false);

            return result;

            throw new InvalidOperationException(result.Errors.Aggregate((a, b) => $"{a} {b}"));
        }

        /// <summary>
        /// Обновляет информацию заданного пользователя в хранилище данных.
        /// </summary>
        /// <param name="user">Экземпляр пользователя для обновления.</param>
        /// <returns> Task </returns>
        public async Task UpdateUser(Common.Models.User.User user)
        {
            var dbUser = Mapper.Map<DbUser>(user);

            var result = await _usermanager.UpdateAsync(dbUser).ConfigureAwait(false);

            if (result.Succeeded)
            {
                return;
            }

            throw new InvalidOperationException(result.Errors.Aggregate((a, b) => $"{a} {b}"));
        }

        /// <summary>
        /// Удаляет пользователя с заданным идентификатором из хранилища данных.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns> Task </returns>
        public async Task DeleteUser(string id)
        {
            var user = await this._usermanager.FindByIdAsync(id).ConfigureAwait(false);

            var result = await _usermanager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return;
            }

            throw new InvalidOperationException(result.Errors.Aggregate((a, b) => $"{a} {b}"));
        }

        /// <summary>
        /// Проверяет наличие пользователя в хранилище данных
        /// соответствующего заданному фильтру.
        /// </summary>
        /// <param name="filter">Лямбда-выражение определяющее фильтр для поиска пользователя.</param>
        /// <returns>Возвращает <see langword="true"/>, если пользователь существует в хранилище данных.</returns>
        public bool UserExists(Expression<Func<Common.Models.User.User, bool>> filter)
        {
            return _unitOfWork.UserRepository.Get(
                           Mapper.Map<Expression<Func<DbUser, bool>>>(filter))
                      .FirstOrDefault() != null;
        }

        /// <summary>
        /// После добавление пользователя в репозитарий
        /// генерирует ссылку, по которой пользователь
        /// в случае получения уведомлении об активации, может
        /// активировать аккаунт.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Ссылку для активации аккаунта.</returns>
        public string CreateConfirmationLink(Common.Models.User.User user)
        {
            // todo надо сделать реализацию, после того, как "прорастут" вьюхи.
            return string.Empty;
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Logging;
using Microsoft.AspNet.Identity;
using Rocket.DAL.Common.UoW;
using Rocket.DAL.Identity;

namespace Rocket.BL.Services.UserServices
{
    public class UserRoleManager : BaseService
    {
        private const string DefaultRoleId = "test"; // todo MP закинуть в хранилище дефолтроль когда будет конкретная база с guid
        private readonly ILog _logger;
        private readonly RocketUserManager _userManager;

        public UserRoleManager(IUnitOfWork unitOfWork, ILog logger, RocketUserManager userManager) : base(unitOfWork)
        {
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// add user to role
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <param name="roleId"> Идентификатор роли. </param>
        /// <returns> Task </returns>
        public virtual async Task<IdentityResult> AddToRole(string userId, string roleId = DefaultRoleId)
        {
            _logger.Trace($"Request AddRole in queue: Role {roleId}, user {userId}");
            var result = await _userManager.AddToRoleAsync(userId, roleId).ConfigureAwait(false);

            _logger.Trace($"Request AddRole complete: user {userId} added to role {roleId}");
            return result;

            //var dbUser = _unitOfWork.UserRepository.Find(userId);
            //var dbUserRole = _unitOfWork.UserRoleRepository.Get(t => t.UserId == userId && t.RoleId == roleId).FirstOrDefault();
            //if (dbUserRole != null)
            //{
            //    //_logger.Trace($" Role {dbRole.Name} was in user: {dbUser.Id} -- {dbUser.FirstName}{dbUser.LastName}");
            //    return;
            //}

            //dbUserRole = new DbUserRole { UserId = userId, RoleId = roleId };
            //_unitOfWork.UserRoleRepository.Insert(dbUserRole);
            //_unitOfWork.SaveChanges();

            //_logger.Fatal(
            //    $"Role {dbRole.Name} was not added to user: {dbUser.Id} -- {dbUser.FirstName}{dbUser.LastName}",
            //    new Exception(string.Join(Environment.NewLine, result.Errors)));
        }

        /// <summary>
        /// Удалить роль у юзера
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <param name="roleId"> Идентификатор роли. </param>
        /// <returns> bool </returns>
        public virtual async Task<IdentityResult> RemoveFromRole(string userId, string roleId)
        {
            _logger.Trace($"Request RemoveFromRole in queue: Role {roleId}, user {userId}");
            var result = await _userManager.RemoveFromRoleAsync(userId, roleId).ConfigureAwait(false);

            _logger.Trace($"Request RemoveFromRole complete: {roleId} removed from {userId}");
            return result;

            //if (!_userManager.IsInRole(userId, roleId))
            //{
            //    throw new InvalidOperationException();
            //    //_logger.Info
            //}

            //_logger.Trace("");

            //var dbUser = _unitOfWork.UserRepository.Find(userId);
            //var dbUserRole = _unitOfWork.UserRoleRepository.Get(t => t.UserId == userId && t.RoleId == roleId).FirstOrDefault();
            //_unitOfWork.UserRoleRepository.Delete(dbUserRole);

            //dbUser.Roles.Remove(dbRole);
            //_logger.Trace($"Role {dbRole.Name} removed from user: {dbUser.Id} -- {dbUser.FirstName}{dbUser.LastName} ");
            //_unitOfWork.SaveChanges();
            //return true;
        }

        /// <summary>
        /// Returns the roles for the user
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <returns>Список ролей</returns>
        public virtual async Task<IList<string>> GetRoles(string userId)
        {
            _logger.Trace($"Request GetRoles : user {userId}");
            return await _userManager.GetRolesAsync(userId).ConfigureAwait(false);

            //    var dbUser = _unitOfWork.UserRepository.Get(t => t.Id == userId, includeProperties: "Roles").First();
            //    _logger.Trace($"Checking roles for user: {dbUser.Id} -- {dbUser.FirstName}{dbUser.LastName} ");
            //    return dbUser.Roles.Select(t => t.Role);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if the user is in the specified role
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <param name="roleId"> Идентификатор роли. </param>
        /// <returns>bool</returns>
        public virtual async Task<bool> IsInRole(string userId, string roleId)
        {
            _logger.Trace($"Request IsInRole : user {userId}");
            return await _userManager.IsInRoleAsync(userId, roleId).ConfigureAwait(false);

            //    if (_unitOfWork.UserRepository.GetById(userId) == null)
            //    {
            //        throw new InvalidOperationException("user not found by userId");
            //    }

            //    var roles = GetRoles(userId);
            //    var res = roles.Contains(_unitOfWork.RoleRepository.GetById(roleId));

            //    _logger.Trace($"Checking user {userId} has role {roleId}? - {res} ");
            //    return res;
            //    throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using AutoMapper;
using Common.Logging;
using Microsoft.AspNet.Identity;
using Rocket.BL.Common.Models.UserRoles;
using Rocket.DAL.Common.DbModels.Identity;
using Rocket.DAL.Common.UoW;
using Rocket.DAL.Identity;

namespace Rocket.BL.Services.UserServices
{
    public static class Permissions
    {
        public static string Read => "read.news";
    }

    /// <summary>
    /// Добавление/удаление пермишенов у ролей + логирование
    /// </summary>
    public class PermissionService : BaseService //, IPermissionService
    {
        private readonly RocketUserManager _userManager;
        private readonly RockeRoleManager _roleManager;
        private readonly ILog _logger;
        private readonly string _claimName = "permission";

        /// <summary>
        /// Создает новый экземпляр <see cref="PermissionService"/>
        /// с заданным unit of work
        /// </summary>
        /// <param name="unitOfWork">Экземпляр unit of work</param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public PermissionService(IUnitOfWork unitOfWork,RocketUserManager userManager,
            RockeRoleManager roleManager, ILog logger): base(unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        /// <summary>
        /// Добавляет пермишен роли
        /// </summary>
        /// <param name="idRole">Идентификатор роли</param>
        /// <param name="idPermission">Идентификатор пермишена</param>
        /*
        public void AddPermissionToRole(string idRole, int idPermission)
        {
            var perm = new Claim("permission", Permissions.Read);
            //var perm = new Claim("permission", Permissions.Read);
            //var perm = new Claim("permission", Permissions.Read);
            _userManager.AddClaim("id", perm);
            //_userManager.AddToRoleAsync();
 


            // докидываем пермишен в роль
            //var dbRole = _unitOfWork.RoleRepository.GetById(idRole);
            //var dbPermission = _unitOfWork.PermissionRepository.GetById(idPermission);
            //dbRole.Permissions.Add(dbPermission);
            //_unitOfWork.SaveChanges();
        }
        */
        /// <summary>
        /// Удоляет пермишен у роли
        /// </summary>
        /// <param name="idRole">Идентификатор роли</param>
        /// <param name="idPermission">Идентификатор пермишена</param>
        /*
        public void RemovePermissionFromRole(string idRole, int idPermission)
        {
            // удаляем пермишен у роли
            var dbRole = _unitOfWork.RoleRepository.GetById(idRole);
            var dbPermission = _unitOfWork.PermissionRepository.GetById(idPermission);
            dbRole.Permissions.Remove(dbPermission);
            _unitOfWork.SaveChanges();
        }
        */

        /// <summary>
        /// Добавляет пермишен
        /// </summary>
        /// <param name="permission">Пермишен</param>
        public void Insert(Permission permission, string user)
        {
            //var permPermissionId = new Claim("permission", permission.PermissionId.ToString());
            var permValueName = new Claim("ValueName", permission.ValueName);
            var permDescription = new Claim("Description", permission.Description);

            //_userManager.AddClaim("id", permPermissionId);
            
            _userManager.AddClaim(user, permValueName);
            _userManager.AddClaim(user, permDescription);
            _logger.Debug($"Permission {permission.Description} added in DB");
            //_userManager.Update(user);
            //var perm = new Claim("permission", Permissions.Read);

            //var dbPermission = Mapper.Map<DbPermission>(permission);
            //_unitOfWork.PermissionRepository.Insert(dbPermission);
            //_unitOfWork.SaveChanges();
        }

        /*
        /// <summary>
        /// Обновляет пермишен
        /// </summary>
        /// <param name="permission">Пермишен</param>
        public void Update(Permission permission, string user)
        {
            var userId = _userManager.FindById(user);

            var claims = _userManager.GetClaimsAsync(userId.ToString());

            var permis = (Claim)claims.Result.FirstOrDefault(a => (a.Type == "ValueName") && (a.Value == permission.ValueName));

            if (permis == null)
            {
                var permValueName = new Claim("ValueName", permission.ValueName);
                var permDescription = new Claim("Description", permission.Description);

                //_userManager.AddClaim("id", permPermissionId);

                _userManager.AddClaim(user, permValueName);
                _userManager.AddClaim(user, permDescription);
                _logger.Debug($"Permission {permission.Description} added in DB");
            }
            else
            {
                return;
            }


            //_userManager.RemoveClaim(user1, );

        
            //var dbPermission = Mapper.Map<DbPermission>(permission);
            //_unitOfWork.PermissionRepository.Update(dbPermission);
            //_unitOfWork.SaveChanges();
        }
        */

        /// <summary>
        /// Удаляет пермишен
        /// </summary>
        /// <param name="id">Идентификатор пермишена</param>
        public void Delete(Permission permission, string user)
        {
            var userId = _userManager.FindById(user);

            var claims = _userManager.GetClaimsAsync(userId.ToString());

            var permis = (Claim)claims.Result.FirstOrDefault(a => (a.Type == "ValueName") && (a.Value == permission.ValueName));

            if (permis == null)
            {
                return;
            }
            else
            {
                _userManager.RemoveClaim(user, permis);
            }
        }

        /// <summary>
        /// Возвращает пермешен с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Permission</returns>
        /*
        public Permission GetById(string id)
        {
            //return Mapper.Map<Permission>(_unitOfWork.PermissionRepository.GetById(id));
            throw new NotImplementedException();
        }
        */

        /// <summary>
        /// Возвращает пермишены роли, нужно для UI
        /// </summary>
        /// <returns>Коллекцию Permission</returns>
        public IEnumerable<Permission> GetAllPermissions()
        {
            var resault = (IEnumerable<Permission>)_userManager.Users.SelectMany(u => u.Claims).ToList();
            
            /*
            var userId = _userManager.FindById(user.Id);

            var claims = _userManager.GetClaimsAsync(userId.ToString());

            var permis = (Claim)claims.Result.FirstOrDefault(a => (a.Type == "ValueName") && (a.Value == permission.ValueName));
            */
            //var bPerm = _unitOfWork.PermissionRepository.Get();
            //IEnumerable<Permission> perm = Mapper.Map<IEnumerable<Permission>>(DbPerm);
            //return perm;
            return resault;
        }

        /// <summary>
        /// Возвращает пермишены роли, нужно для UI
        /// </summary>
        /// <param name="idRole">Идентификатор роли</param>
        /// <returns>Коллекцию Permission</returns>
        public IEnumerable<Permission> GetPermissionByYser(string user)
        {
            var userId = _userManager.FindById(user);

            var claims = _userManager.GetClaimsAsync(userId.ToString());

            var permis = (IEnumerable<Permission>)claims.Result;

            return permis;
            //var rol = _unitOfWork.RoleRepository.GetById(idRole);
            //return Mapper.Map<Role>(rol)?.Permissions;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает пермишены по фильтру
        /// </summary>
        /// <returns>Коллекцию Permission</returns>
        /*
        public IEnumerable<Permission> Get(
            Expression<Func<DbPermission, bool>> filter = null,
            Func<IQueryable<DbPermission>, IOrderedQueryable<DbPermission>> orderBy = null,
            string includeProperties = "")
        {
            return _unitOfWork.PermissionRepository.Get(filter, orderBy, includeProperties).Select(Mapper.Map<Permission>);
        }
        */
        /*
        public void IsExistPermissionInUser(DAL.Common.DbModels.User.DbUser User, int idPermission)
        {
            // докидываем пермишен в роль
            var role = Mapper.Map<DbRole>(_unitOfWork.RoleRepository.GetById(idRole));
            var permission = Mapper.Map<DbPermission>(_unitOfWork.PermissionRepository.GetById(idPermission));
            role.Permissions.Add(permission);
            _unitOfWork.SaveChanges();
        }
        */
    }
}
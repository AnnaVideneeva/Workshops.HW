using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using AutoMapper;
using Common.Logging;
using Microsoft.AspNet.Identity;
using Rocket.BL.Common.Models.UserRoles;
using Rocket.BL.Common.Services;
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
    public class PermissionManagerService : BaseService, IPermissionService
    {
        private readonly RocketUserManager _userManager;
        private readonly RockeRoleManager _roleManager;
        private readonly ILog _logger;
        private readonly string _srtingClaims = "permission";

        /// <summary>
        /// Создает новый экземпляр <see cref="PermissionManagerService"/>
        /// с заданным unit of work
        /// </summary>
        /// <param name="unitOfWork">Экземпляр unit of work</param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public PermissionManagerService(IUnitOfWork unitOfWork,
            RocketUserManager userManager,
            RockeRoleManager roleManager, 
            ILog _logger)
            : base(unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this._logger = _logger;
        }

        /// <summary>
        /// Добавляет пермишен роли
        /// </summary>
        /// <param name="idRole">Идентификатор роли</param>
        /// <param name="idPermission">Идентификатор пермишена</param>
        public void AddPermissionToRole(string idRole, int idPermission)
        {
           var perm = new Claim("permission", Permissions.Read);
            //var perm = new Claim("permission", Permissions.Read);
            //var perm = new Claim("permission", Permissions.Read);
            //var perm = new Claim("permission", Permissions.Read);
            //var perm = new Claim("permission", Permissions.Read);
            _userManager.AddClaim("id", perm);
            //_userManager.AddToRoleAsync();
            throw new NotImplementedException();


            // докидываем пермишен в роль
            var dbRole = _unitOfWork.RoleRepository.GetById(idRole);
            var dbPermission = _unitOfWork.PermissionRepository.GetById(idPermission);
            dbRole.Permissions.Add(dbPermission);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Удоляет пермишен у роли
        /// </summary>
        /// <param name="idRole">Идентификатор роли</param>
        /// <param name="idPermission">Идентификатор пермишена</param>
        public void RemovePermissionFromRole(string idRole, int idPermission)
        {
            // удаляем пермишен у роли
            var dbRole = _unitOfWork.RoleRepository.GetById(idRole);
            var dbPermission = _unitOfWork.PermissionRepository.GetById(idPermission);
            dbRole.Permissions.Remove(dbPermission);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Добавляет пермишен
        /// </summary>
        /// <param name="permission">Пермишен</param>
        public void Insert(Permission permission)
        {
            //_srtingClaims
            //var PermissionClaim = new Claim("id", permission.PermissionId.ToString());
            var permValueName = new Claim("ValueName", permission.ValueName);
            var permDescription = new Claim("Description", permission.Description);

            _userManager.AddClaim(_srtingClaims, permValueName);
            _userManager.AddClaim(_srtingClaims, permDescription);
            
            _logger.Debug($"Permission {permission.Description} added in DB");
            //var perm = new Claim("permission", Permissions.Read);
            //var perm = new Claim("permission", Permissions.Read);
            //var perm = new Claim("permission", Permissions.Read);
            //var perm = new Claim("permission", Permissions.Read);


            //var dbPermission = Mapper.Map<DbPermission>(permission);
            //_unitOfWork.PermissionRepository.Insert(dbPermission);
            //_unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Обновляет пермишен
        /// </summary>
        /// <param name="permission">Пермишен</param>
        public void Update(Permission permission)
        {
            var permPermissionId = new Claim("permission", permission.PermissionId.ToString());
            var permValueName = new Claim("permission", permission.ValueName);
            var permDescription = new Claim("permission", permission.Description);

            var perm = _roleManager.FindById(permission.PermissionId.ToString());
            _userManager.AddClaim("id", permPermissionId);
            _userManager.AddClaim("id", permValueName);
            _userManager.AddClaim("id", permDescription);
            _logger.Debug($"Permission {permission.Description} added in DB");
            //_userManager.GetClaims()

            //var dbPermission = Mapper.Map<DbPermission>(permission);
            //_unitOfWork.PermissionRepository.Update(dbPermission);
            //_unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Удаляет пермишен
        /// </summary>
        /// <param name="id">Идентификатор пермишена</param>
        public void Delete(string id)
        {
            _unitOfWork.PermissionRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Возвращает пермешен с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Permission</returns>
        public Permission GetById(string id)
        {
            return Mapper.Map<Permission>(_unitOfWork.PermissionRepository.GetById(id));
        }

        /// <summary>
        /// Возвращает пермишены роли, нужно для UI
        /// </summary>
        /// <returns>Коллекцию Permission</returns>
        public IEnumerable<Permission> GetAllPermissions()
        {
            var DbPerm = _unitOfWork.PermissionRepository.Get();
            IEnumerable<Permission> perm = Mapper.Map<IEnumerable<Permission>>(DbPerm);
            return perm;
        }

        /// <summary>
        /// Возвращает пермишены роли, нужно для UI
        /// </summary>
        /// <param name="idRole">Идентификатор роли</param>
        /// <returns>Коллекцию Permission</returns>
        public IEnumerable<Permission> GetPermissionByRole(string idRole)
        {
            var rol = _unitOfWork.RoleRepository.GetById(idRole);
            return Mapper.Map<Role>(rol)?.Permissions;
        }

        /// <summary>
        /// Возвращает пермишены по фильтру
        /// </summary>
        /// <returns>Коллекцию Permission</returns>
        public IEnumerable<Permission> Get(
            Expression<Func<DbPermission, bool>> filter = null,
            Func<IQueryable<DbPermission>, IOrderedQueryable<DbPermission>> orderBy = null,
            string includeProperties = "")
        {
            return _unitOfWork.PermissionRepository.Get(filter, orderBy, includeProperties).Select(Mapper.Map<Permission>);
        }

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
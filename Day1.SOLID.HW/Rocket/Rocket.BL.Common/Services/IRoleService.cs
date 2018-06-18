using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Rocket.BL.Common.Models.UserRoles;
using Rocket.DAL.Common.DbModels.Identity;

namespace Rocket.BL.Common.Services
{
    public interface IRoleService : IDisposable
    {
        /// <summary>
        /// Удаляем модель по Id
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        Task<IdentityResult> Delete(string id);

        /// <summary>
        /// Получаем список ролей с фильтрами и сортировкой
        /// </summary>
        /// <param name="filter"> фильтр </param>
        /// <param name="orderBy"> слортировка </param>
        /// <param name="includeProperties"> доп проперти </param>
        /// <returns> list </returns>
        IEnumerable<Role> GetAll(
            Expression<Func<DbRole, bool>> filter = null, 
            Func<IQueryable<DbRole>, IOrderedQueryable<DbRole>> orderBy = null, 
            string includeProperties = "");

        /// <summary>
        /// Получаем роль по Id
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <returns>Role</returns>
        Task<Role> GetById(string id);

        /// <summary>
        /// Добавляем новую роль
        /// </summary>
        /// <param name="role"> Роль </param>
        Task<IdentityResult> Insert(Role role);

        /// <summary>
        /// Проверка существования данной роли
        /// </summary>
        /// <param name="filter"> фильтр </param>
        /// <returns> bool </returns>
        Task<bool> RoleIsExists(string filter);

        /// <summary>
        /// Обновляем текущую роль
        /// </summary>
        /// <param name="roleId"> Роль </param>
        /// <param name="roleName">Role name.</param>
        Task<IdentityResult> Update(string roleId, string roleName);
    }
}
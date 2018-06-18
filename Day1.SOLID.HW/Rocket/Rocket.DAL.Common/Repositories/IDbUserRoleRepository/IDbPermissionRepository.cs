using Rocket.DAL.Common.DbModels.Identity;

namespace Rocket.DAL.Common.Repositories.IDbUserRoleRepository
{
    /// <summary>
    /// Репозиторий для работы с правами
    /// </summary>
    public interface IDbPermissionRepository : IBaseRepository<DbPermission>
    {
    }
}
using Rocket.DAL.Common.DbModels.Identity;

namespace Rocket.DAL.Common.Repositories.IDbUserRoleRepository
{
    /// <summary>
    /// Репозиторий для управления ролями
    /// </summary>
    public interface IDbRoleRepository : IBaseRepository<DbRole>
    {
    }
}
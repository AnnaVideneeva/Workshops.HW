using Rocket.DAL.Common.DbModels.Identity;
using Rocket.DAL.Common.Repositories.IDbUserRoleRepository;
using Rocket.DAL.Context;

namespace Rocket.DAL.Repositories.UserRole
{
    public class DbPermissionRepository : BaseRepository<DbPermission>, IDbPermissionRepository
    {
        public DbPermissionRepository(RocketContext rocketContext) : base(rocketContext)
        {
        }
    }
}

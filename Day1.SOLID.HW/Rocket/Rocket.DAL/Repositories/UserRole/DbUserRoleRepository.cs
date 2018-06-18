using Rocket.DAL.Common.DbModels.Identity;
using Rocket.DAL.Common.Repositories.IDbUserRoleRepository;
using Rocket.DAL.Context;

namespace Rocket.DAL.Repositories.UserRole
{
    public class DbUserRoleRepository : BaseRepository<DbUserRole>, IDbUserRoleRepository
    {
        public DbUserRoleRepository(RocketContext rocketContext) : base(rocketContext)
        {
        }
    }
}
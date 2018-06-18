using Rocket.DAL.Common.DbModels.Identity;
using Rocket.DAL.Common.Repositories.IDbUserRoleRepository;
using Rocket.DAL.Context;

namespace Rocket.DAL.Repositories.UserRole
{
    public class DbRoleRepository : BaseRepository<DbRole>, IDbRoleRepository
    {
        public DbRoleRepository(RocketContext rocketContext) : base(rocketContext)
        {
        }
    }
}

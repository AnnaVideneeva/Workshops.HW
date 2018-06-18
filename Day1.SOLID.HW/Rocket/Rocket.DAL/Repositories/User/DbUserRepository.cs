using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Common.Repositories.User;
using Rocket.DAL.Context;

namespace Rocket.DAL.Repositories.User
{
    public class DbUserRepository : BaseRepository<DbUser>, IDbUserRepository
    {
        public DbUserRepository(RocketContext rocketContext) : base(rocketContext)
        {
        }
    }
}

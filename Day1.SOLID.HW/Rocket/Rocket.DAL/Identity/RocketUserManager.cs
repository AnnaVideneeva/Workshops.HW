using Microsoft.AspNet.Identity;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Identity
{
    public class RocketUserManager : UserManager<DbUser>
    {
        public RocketUserManager(IUserStore<DbUser> store) : base(store)
        {
        }
    }
}
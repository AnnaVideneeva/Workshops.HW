using Microsoft.AspNet.Identity.EntityFramework;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Common.DbModels.Identity
{
    public class DbUserClaim : IdentityUserClaim<int>
    {
        public virtual DbUser User { get; set; }
    }
}
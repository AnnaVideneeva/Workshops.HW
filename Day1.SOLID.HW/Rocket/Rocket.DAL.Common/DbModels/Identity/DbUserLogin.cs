using Microsoft.AspNet.Identity.EntityFramework;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Common.DbModels.Identity
{
    public class DbUserLogin : IdentityUserLogin<int>
    {
        public virtual DbUser User { get; set; }
    }
}

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Rocket.DAL.Common.DbModels.Identity;

namespace Rocket.DAL.Identity
{
    public class RockeRoleManager : RoleManager<DbRole>
    {
        public RockeRoleManager(IRoleStore<DbRole, string> store) : base(store)
        {
        }
    }
}
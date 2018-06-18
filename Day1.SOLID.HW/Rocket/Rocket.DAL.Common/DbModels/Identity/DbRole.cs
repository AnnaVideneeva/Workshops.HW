using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rocket.DAL.Common.DbModels.Identity
{
    public class DbRole : IdentityRole
    {
        /// <summary>
        /// список пермишенов для роли
        /// </summary>
        public virtual ICollection<DbPermission> Permissions { get; set; }
    }
}
using System.Collections.Generic;

namespace Rocket.BL.Common.Models.UserRoles
{
    public class Permission
    {
        /// <summary>
        /// uniq identificator of permission
        /// </summary>
        public int PermissionId { get; set; }

        /// <summary>
        /// description of permission
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// name of Value
        /// </summary>
        public string ValueName { get; set; }
    }
}
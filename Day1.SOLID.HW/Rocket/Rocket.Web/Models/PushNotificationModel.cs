using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rocket.BL.Common.Models.User;

namespace Rocket.Web.Models
{
    public class PushNotificationModel
    {
        public string Message { get; set; }

        public string[] Users { get; set; }
    }
}
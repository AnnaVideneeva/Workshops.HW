using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Common.Logging;
using Rocket.Web.Helpers;
using Rocket.Web.Models;

namespace Rocket.Web.Controllers
{
    [System.Web.Http.RoutePrefix("api/notifications")]
    public class NotificationsController : ApiController
    {
        private readonly IPushNotificationsHelper _pushNotificationsHelper;
        private readonly ILog _log;

        public NotificationsController(IPushNotificationsHelper pushNotificationsHelper, ILog log)
        {
            _pushNotificationsHelper = pushNotificationsHelper;
            _log = log;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("notifyOfReleasePush")]
        public ActionResult NotifyOfReleasePush(IEnumerable<PushNotificationModel> notifications)
        {
            try
            {
                _pushNotificationsHelper.SendPushNotificationsOfRelease(notifications);

            }
            catch (Exception e)
            {
                throw e;
            }

            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Rocket.Web.Hubs
{
    [HubName("notification")]
    public class NotificationHub : Hub
    {
        private static readonly IHubContext HubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        [HubMethodName("sendMessage")]
        public void SendMessage(object msg)
        {
            Clients.All.sendMessage(msg);
        }

        [HubMethodName("notifyOfRelease")]
        public static void NotifyOfRelease(object msg, string[] users)
        {
            HubContext.Clients.Users(users).notifyOfRelease(msg);
        }
    }
}
using System;
using Ninject;
using Quartz;
using Rocket.Notifications.Heplers;
using Rocket.Notifications.Interfaces;

namespace Rocket.Notifications.Jobs
{
    /// <inheritdoc />
    /// <summary>
    /// Джоба для отправки push-уведомелений
    /// </summary>
    [DisallowConcurrentExecution]
    internal class NotificationsJob : IJob
    {
        /// <inheritdoc />
        /// <summary>
        /// Запуск отправки push-уведомелений 
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var schedulerContext = context.JobDetail.JobDataMap;
                var kernel = (IKernel)schedulerContext.Get(CommonHelper.ContainerKey);

                var pushNotificator = kernel.Get<IPushNotificator>();
                pushNotificator.NotifyAsync().Wait();
            }
            catch (Exception excpt)
            {
                throw excpt;
            }
        }

    }
}

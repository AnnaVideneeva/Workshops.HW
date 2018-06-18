using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Quartz;
using Rocket.DAL.Common.DbModels.Notification;
using Rocket.DAL.Common.Repositories;
using Rocket.Notifications.Heplers;
using Rocket.Notifications.Jobs;
using Rocket.Notifications.Properties;
using Rocket.Notifications.Services;
using Rocket.Web;
using Topshelf;
using Topshelf.Quartz;
using Topshelf.ServiceConfigurators;

namespace Rocket.Notifications
{
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //Подключаем IoC
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                var kernel = BootstrapHelper.LoadNinjectKernel(assemblies);
                MapperConfig.Initialize();

                HostFactory.Run(configurator =>
                {
                    //конфигурируем Topshelf.Quartz
                    configurator.Service<TopshelfService>(serviceConfigurator =>
                    {
                        serviceConfigurator.ConstructUsing(name => new TopshelfService());
                        serviceConfigurator.WhenStarted((service, control) => service.Start(control));
                        serviceConfigurator.WhenStopped((service, control) => service.Stop(control));

                        //Запуск процесса рассылки уведомлений 
                        NotificationsProcess(serviceConfigurator, kernel);
                    });

                    configurator.StartAutomatically();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Добавляет в конфигуратор Quartz задание по расписанию для уведомлений.
        /// </summary>
        /// <param name="serviceConfigurator">Конфигуратор Quartz.</param>
        /// <param name="kernel">DI контейнер</param>
        private static void NotificationsProcess(
            ServiceConfigurator<TopshelfService> serviceConfigurator, IKernel kernel)
        {
            try
            {
                var notificationsSettingsRepository = kernel.Get<IBaseRepository<NotificationsSettingsEntity>>();
                var resource = notificationsSettingsRepository
                    .Queryable().First(r => r.Name.Equals(Resources.NotificationsSettings));

                var notificationsIsSwitchOn = resource.NotifyIsSwitchOn;
                var notificationsPeriodInMinutes = resource.NotifyPeriodInMinutes;

                if (!notificationsIsSwitchOn) return;

                ITrigger NotificationsTrigger() => TriggerBuilder.Create()
                    .WithSimpleSchedule(builder => builder.WithIntervalInMinutes(notificationsPeriodInMinutes)
                        .WithMisfireHandlingInstructionIgnoreMisfires()
                        .RepeatForever())
                    .Build();

                IJobDetail notificationsTriggerJob = JobBuilder.Create<NotificationsJob>().Build();
                notificationsTriggerJob.JobDataMap.Put(CommonHelper.ContainerKey, kernel);

                // Запускает уведомления
                serviceConfigurator.ScheduleQuartzJob(jobConfigurator =>
                    jobConfigurator
                        .WithJob(() => notificationsTriggerJob)
                        .AddTrigger(NotificationsTrigger));

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}

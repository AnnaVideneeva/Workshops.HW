using System;
using Ninject;
using Quartz;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.Repositories;
using Rocket.Parser.Heplers;
using Rocket.Parser.Jobs;
using Rocket.Parser.Properties;
using Rocket.Parser.Services;
using Topshelf;
using Topshelf.Quartz;
using Topshelf.ServiceConfigurators;
using System.Linq;

namespace Rocket.Parser
{
    public class Program
    {
        private static void Main()
        {
            try
            {
                //Подключаем IoC
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                var kernel = BootstrapHelper.LoadNinjectKernel(assemblies);

                HostFactory.Run(configurator =>
                {
                    //конфигурируем Topshelf.Quartz
                    configurator.Service<TopshelfService>(serviceConfigurator =>
                    {
                        serviceConfigurator.ConstructUsing(name => new TopshelfService());
                        serviceConfigurator.WhenStarted((service, control) => service.Start(control));
                        serviceConfigurator.WhenStopped((service, control) => service.Stop(control));

                        //Запуск парсера для Lostfilm
                        LostfilmParseProcess(serviceConfigurator, kernel);

                        //Запуск парсера для AlbumInfo  
                        AlbumInfoParseProcess(serviceConfigurator, kernel);
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
        /// Добавляет в конфигуратор Quartz задание по расписанию для парсинга Lostfilm.
        /// </summary>
        /// <param name="serviceConfigurator">Конфигуратор Quartz.</param>
        /// <param name="kernel">DI контейнер</param>
        private static void LostfilmParseProcess(
            ServiceConfigurator<TopshelfService> serviceConfigurator, IKernel kernel)
        {
            var resourceRepository = kernel.Get<IBaseRepository<ResourceEntity>>();
            var resource = resourceRepository
                .Queryable().First(r => r.Name.Equals(Resources.LostfilmSettings));

            var lostfilmParseIsSwitchOn = resource.ParseIsSwitchOn;
            var lostfilmParsePeriodInMinutes = resource.ParsePeriodInMinutes;

            if (!lostfilmParseIsSwitchOn) return;

            ITrigger LostfilmParseTrigger() => TriggerBuilder.Create()
                .WithSimpleSchedule(builder => builder.WithIntervalInMinutes(lostfilmParsePeriodInMinutes)
                    .WithMisfireHandlingInstructionIgnoreMisfires()
                    .RepeatForever())
                .Build();

            // Запускает парсер Lostfilm
            var lostfilmParseTriggerJob = JobBuilder.Create<LostfilmParseJob>().Build();
            lostfilmParseTriggerJob.JobDataMap.Put(CommonHelper.ContainerKey, kernel);

            serviceConfigurator.ScheduleQuartzJob(jobConfigurator =>
                jobConfigurator
                    .WithJob(() => lostfilmParseTriggerJob)
                    .AddTrigger(LostfilmParseTrigger));
        }

        /// <summary>
        /// Добавляет в конфигуратор Quartz задание по расписанию для парсинга album-info.ru.
        /// </summary>
        /// <param name="serviceConfigurator">Конфигуратор Quartz.</param>
        /// <param name="kernel">DI контейнер</param>
        private static void AlbumInfoParseProcess(
            ServiceConfigurator<TopshelfService> serviceConfigurator, IKernel kernel)
        {
            var resourceRepository = kernel.Get<IBaseRepository<ResourceEntity>>();
            var resource = resourceRepository
                .Queryable().First(r => r.Name.Equals(Resources.AlbumInfoSettings));

            var albumInfoParseIsSwitchOn = resource.ParseIsSwitchOn;
            var albumInfoParsingPeriodInMinutes = resource.ParsePeriodInMinutes;

            if (!albumInfoParseIsSwitchOn) return;

            ITrigger AlbumInfoParseTrigger() => TriggerBuilder.Create()
                .WithSimpleSchedule(builder => builder.WithIntervalInMinutes(albumInfoParsingPeriodInMinutes)
                    .WithMisfireHandlingInstructionIgnoreMisfires()
                    .RepeatForever())
                .Build();
            
            IJobDetail albumInfoParseTriggerJob = JobBuilder.Create<AlbumInfoParseJob>().Build();
            albumInfoParseTriggerJob.JobDataMap.Put(CommonHelper.ContainerKey, kernel);

            // Запускает парсер album-info.ru
            serviceConfigurator.ScheduleQuartzJob(jobConfigurator =>
                jobConfigurator
                    .WithJob(() => albumInfoParseTriggerJob)
                    .AddTrigger(AlbumInfoParseTrigger));
        }
    }
}

using System;
using Ninject;
using Quartz;
using Rocket.Parser.Heplers;
using Rocket.Parser.Interfaces;

namespace Rocket.Parser.Jobs
{
    /// <summary>
    /// Джоба для парсинга сайта lostfilm.tv
    /// </summary>
    [DisallowConcurrentExecution]
    internal class LostfilmParseJob : IJob
    {
        /// <summary>
        /// Парсит Lostfilm.
        /// </summary>
        /// <param name="context">context</param>
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var schedulerContext = context.JobDetail.JobDataMap;
                var kernel = (IKernel)schedulerContext.Get(CommonHelper.ContainerKey);
                
                var lostfilmParseService = kernel.Get<ILostfilmParser>();
                lostfilmParseService.ParseAsync().Wait();
            }
            catch (Exception excpt)
            {
                throw excpt;
            }
        }
    }
}
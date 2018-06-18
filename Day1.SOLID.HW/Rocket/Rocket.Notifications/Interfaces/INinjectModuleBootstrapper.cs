using System.Collections.Generic;
using Ninject.Modules;

namespace Rocket.Notifications.Interfaces
{
    /// <summary>
    /// Предоставляет список модулей ninject
    /// </summary>
    public interface INinjectModuleBootstrapper
    {
        /// <summary>
        /// Возвращает список модулей ninject
        /// </summary>
        /// <returns>Список INinjectModule</returns>
        IList<INinjectModule> GetModules();
    }
}

using Topshelf;

namespace Rocket.Parser.Services
{
    /// <summary>
    /// Сервис для корректной работы Topshelf, необходимо реализовать интерфейс ServiceControl
    /// </summary>
    public class TopshelfService : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}
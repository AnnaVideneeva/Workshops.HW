using System.Threading.Tasks;

namespace Rocket.Parser.Interfaces
{
    /// <summary>
    /// Базовый интерфейс парсера
    /// </summary>
    internal interface IParser
    {
        /// <summary>
        /// Запуск процесса парсинга
        /// </summary>
        /// <returns>Task</returns>
        Task ParseAsync();
    }
}

using Rocket.BL.Common.Models.Subscription;

namespace Rocket.BL.Common.Models.ReleaseList
{
    public class Musician : Subscribable
    {
        /// <summary>
        /// Возвращает или задает полное имя музыкального исполнителя (название группы)
        /// </summary>
        public string FullName { get; set; }
    }
}
namespace Rocket.DAL.Common.DbModels.Notification
{
    /// <summary>
    /// Содержит настроки для работы сервиса уведомлений
    /// </summary>
    public class NotificationsSettingsEntity
    {
        /// <summary>
        /// Id сервиса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название сервиса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вкл/откл джобы
        /// </summary>
        public bool NotifyIsSwitchOn { get; set; }

        /// <summary>
        /// Интервал запуска джобы в минутах
        /// </summary>
        public int NotifyPeriodInMinutes { get; set; }

        /// <summary>
        /// Url для отправки push-уведомлений
        /// </summary>
        public string PushUrl { get; set; }
    }
}

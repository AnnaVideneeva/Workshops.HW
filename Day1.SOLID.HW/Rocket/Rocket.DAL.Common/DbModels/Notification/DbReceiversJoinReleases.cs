namespace Rocket.DAL.Common.DbModels.Notification
{
    /// <summary>
    /// Описывает модель хранения сводных данных о пользователе
    /// и релизе
    /// </summary>
    public class DbReceiversJoinReleases
    {
        /// <summary>
        /// Возвращает или задает получателя сообщения о релизе
        /// </summary>
        public DbReceiver Receiver { get; set; }

        /// <summary>
        /// Возвращает или задает идентификационный номер
        /// получателя сообщения о релизе
        /// </summary>
        public int ReceiverId { get; set; }

        /// <summary>
        /// Возвращает или задает сообщение о релизе
        /// </summary>
        public DbReleaseMessage ReleaseMessage { get; set; }

        /// <summary>
        /// Возвращает или задает идентификационный номер сообщения о релизе
        /// </summary>
        public int ReleaseMessageId { get; set; }

        /// <summary>
        /// Возвращает или задает флаг просмотра пользователем
        /// push нотификации
        /// </summary>
        public bool Viewed { get; set; }
    }
}
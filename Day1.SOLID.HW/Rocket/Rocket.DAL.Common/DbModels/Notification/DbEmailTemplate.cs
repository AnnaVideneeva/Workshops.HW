namespace Rocket.DAL.Common.DbModels.Notification
{
    /// <summary>
    /// Описывает модель хранения данных о шаблоне email сообщения
    /// </summary>
    public class DbEmailTemplate
    {
        /// <summary>
        /// Возвращает или задает идентификационный номер шаблона
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает наименование шаблона
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Возвращает или задает строковое представление тела шаблона
        /// </summary>
        public string Body { get; set; }
    }
}
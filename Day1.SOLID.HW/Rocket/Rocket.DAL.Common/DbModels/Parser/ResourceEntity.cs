using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.Parser
{
    /// <summary>
    /// Содержит информацию о ресурсе для парсинга
    /// </summary>
    public class ResourceEntity
    {
        /// <summary>
        /// Id ресурса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название ресурса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на страницу ресурса
        /// </summary>
        public string ResourceLink { get; set; }

        /// <summary>
        /// Вкл/откл джобы
        /// </summary>
        public bool ParseIsSwitchOn { get; set; }

        /// <summary>
        /// Интервал запуска джобы в минутах
        /// </summary>
        public int ParsePeriodInMinutes { get; set; }

        /// <summary>
        /// Коллекция настроек
        /// </summary>
        public ICollection<ParserSettingsEntity> ParserSettings { get; set; }

        /// <summary>
        /// Коллекция элементов ресурса
        /// </summary>
        public ICollection<ResourceItemEntity> ResourceItems { get; set; }
    }
}

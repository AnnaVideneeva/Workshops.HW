using System;
using Rocket.DAL.Common.DbModels.ReleaseList;

namespace Rocket.DAL.Common.DbModels.Parser
{
    /// <summary>
    /// Элемент ресурса
    /// </summary>
    public class ResourceItemEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id типа ресурса
        /// </summary>
        public int ResourceId { get; set; }

        /// <summary>
        /// Id внутри ресурса
        /// </summary>
        public string ResourceInternalId { get; set; }

        /// <summary>
        /// Ссылка на страницу элемента ресурса
        /// </summary>
        public string ResourceItemLink { get; set; }

        /// <summary>
        /// Дата и веремя создания
        /// </summary>
        public DateTime CreatedDateTime { get; private set; }

        /// <summary>
        /// Дата и веремя последней обработки
        /// </summary>
        public DateTime LastModified { get; private set; } //todo add trigger on table

        /// <summary>
        /// Ссылка на ресурс
        /// </summary>
        public ResourceEntity Resource { get; set; }

        /// <summary>
        /// Id музыкального релиза
        /// </summary>
        public int MusicId { get; set; }

        /// <summary>
        /// Музыкальный релиз
        /// </summary>
        public DbMusic Music { get; set; }
    }
}

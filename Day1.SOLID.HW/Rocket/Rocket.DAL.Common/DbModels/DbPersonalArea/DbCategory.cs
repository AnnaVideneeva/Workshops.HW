using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.DbPersonalArea
{
    /// <summary>
    /// Модель хранения данных категорий фильмов, сериалов и музыки.
    /// </summary>
    public class DbCategory
    {
        /// <summary>
        /// Id категории.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список связанных жанров с данной категорией.
        /// </summary>
        public virtual ICollection<DbGenre> Genres { get; set; }
    }
}
using System.Collections.Generic;

namespace Rocket.BL.Common.Models.PersonalArea
{
    /// <summary>
    /// Класс, содержащий данные о категории (фильм, сериал или музыка).
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Id категории.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя категории.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список жанров данной категории.
        /// </summary>
        public ICollection<Genre> Genres { get; set; }
    }
}
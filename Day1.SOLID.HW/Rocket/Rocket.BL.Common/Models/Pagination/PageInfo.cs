using System.Collections.Generic;

namespace Rocket.BL.Common.Models.Pagination
{
    /// <summary>
    /// Представляет модель информации о странице экземпляров <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции</typeparam>
    public class PageInfo<T>
    {
        /// <summary>
        /// Возвращает или задает коллекцию элементов страницы
        /// </summary>
        public IEnumerable<T> PageItems { get; set; }

        /// <summary>
        /// Возвращает или задает количество всех страниц
        /// </summary>
        public int TotalPagesCount { get; set; }

        /// <summary>
        /// Возвращает или задает количество всех элементов
        /// </summary>
        public int TotalItemsCount { get; set; }
    }
}
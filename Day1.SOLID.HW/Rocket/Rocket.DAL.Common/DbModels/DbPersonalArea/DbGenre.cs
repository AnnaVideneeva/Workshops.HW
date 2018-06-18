using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.DbPersonalArea
{
    /// <summary>
    /// Модель хранения данных жанров фильмов, сериалов и музыки.
    /// </summary>
    public class DbGenre
    {
        /// <summary>
        /// Id жанра определенной категории.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название жанра.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внешний  ключ к таблице Category.
        /// </summary>
        public int? DbCategoryId { get; set; }

        /// <summary>
        /// Ссылка на связанную Category.
        /// </summary>
        public DbCategory DbCategory { get; set; }

        /// <summary>
        /// Коллекция AuthorisedUser, подписанных на данный жанр.
        /// </summary>
        public ICollection<DbAuthorisedUser> AuthorisedUsers { get; set; }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rocket.BL.Common.Models.Subscription
{
    /// <summary>
    /// Представляет базовую модель ресурсов, на которые возможна подписка
    /// </summary>
    public abstract class Subscribable
    {
        /// <summary>
        /// Уникальный идентификатор ресурса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Коллекция пользователей подписанных на данный ресурс
        /// </summary>
        public ICollection<User.User> Users { get; set; } = new Collection<User.User>();
    }
}

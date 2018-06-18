using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Common.DbModels.Subscription
{
    /// <summary>
    /// Представляет базовую модель ресурсов, на которые возможна подписка
    /// </summary>
    public abstract class SubscribableEntity
    {
        /// <summary>
        /// Уникальный идентификатор ресурса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Коллекция пользователей подписанных на данный ресурс
        /// </summary>
        public ICollection<DbUser> Users { get; set; } = new Collection<DbUser>();
    }
}

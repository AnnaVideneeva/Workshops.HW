using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.Repositories.IDbPersonalAreaRepository;
using Rocket.DAL.Context;

namespace Rocket.DAL.Repositories.PersonalArea
{
    /// <summary>
    /// Репозиторий пользователей личного кабинета.
    /// </summary>
    public class DbUserProfileRepository : BaseRepository<DbUserProfile>, IDbUserProfileRepository
    {
        /// <summary>
        /// Создает новый экземпляр репозитория для пользователей личного кабинета с заданным контекстом базы данных.
        /// </summary>
        /// <param name="context">Экземпляр контекста базы данных.</param>
        public DbUserProfileRepository(RocketContext context) : base(context)
        {
        }
    }
}
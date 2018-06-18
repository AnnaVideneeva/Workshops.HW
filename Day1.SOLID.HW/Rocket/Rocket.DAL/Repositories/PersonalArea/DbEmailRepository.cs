using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.Repositories.IDbPersonalAreaRepository;
using Rocket.DAL.Context;

namespace Rocket.DAL.Repositories.PersonalArea
{
    /// <summary>
    /// Репозиторий e-mail.
    /// </summary>
    public class DbEmailRepository : BaseRepository<DbEmail>, IDbEmailRepository
    {
        /// <summary>
        /// Создает новый экземпляр репозитория для e-mail с заданным контекстом базы данных.
        /// </summary>
        /// <param name="context">Экземпляр контекста базы данных.</param>
        public DbEmailRepository(RocketContext context) : base(context)
        {
        }
    }
}
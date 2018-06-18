using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Common.Repositories.User
{
    /// <summary>
    /// Представляет репозитарий для пользователей.
    /// </summary>
    public interface IDbUserRepository : IBaseRepository<DbUser>
    {
    }
}
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Common.Repositories.User
{
    /// <summary>
    /// Представляет репозитарий для дополнительной информации пользователей.
    /// </summary>
    public interface IDbUserDetailRepository : IBaseRepository<DbUserDetail>
    {
    }
}
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Common.Repositories.User
{
    /// <summary>
    /// Представляет репозитарий сведений о том, как называть пользователя.
    /// </summary>
    public interface IDbHowToCallRepository : IBaseRepository<DbHowToCall>
    {
    }
}
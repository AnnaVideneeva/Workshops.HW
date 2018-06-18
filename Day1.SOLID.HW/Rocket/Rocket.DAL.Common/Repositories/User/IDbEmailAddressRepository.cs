using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Common.Repositories.User
{
    /// <summary>
    /// Представляет репозитарий электронных адресов дополнительной информации пользователя.
    /// </summary>
    public interface IDbEmailAddressRepositary : IBaseRepository<DbEmailAddress>
    {
    }
}
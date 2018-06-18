using Rocket.DAL.Common.DbModels.DbUser.DbAccount;

    namespace Rocket.DAL.Common.Repositories.IDbUserRepository.IDbAccountRepository
    {
        /// <summary>
        /// Представляет репозитарий для данных аккаунта пользователя
        /// </summary>
        public interface IDbAccountRepository : IBaseRepository<DbAccount>
        { 
        }
    }

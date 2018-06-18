using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rocket.BL.Common.Services.User
{
    /// <summary>
    /// Представляет сервис для работы с пользователем.
    /// </summary>
    public interface IUserManagementService : IDisposable
    {
        /// <summary>
        /// Возвращает всех пользователей
        /// из хранилища данных.        
        /// </summary>
        /// <returns>Коллекцию всех экземпляров пользователей.</returns>
        ICollection<Models.User.User> GetAllUsers();

        /// <summary>
        /// Возвращает пользователей
        /// из хранилища данных для пейджинга.
        /// </summary>
        /// <param name="pageSize">Количество сведений о пользователях, выводимых на страницу.</param>
        /// <param name="pageNumber">Номер выводимой страницы со сведениями о пользователях.</param>
        /// <returns>Коллекция экземпляров пользователей для пейджинга.</returns>
        ICollection<Models.User.User> GetUsersPage(int pageSize, int pageNumber);

        /// <summary>
        /// Возвращает пользователя с заданным идентификатором
        /// из хранилища данных.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Экземпляр пользователя.</returns>
        Task<Models.User.User> GetUser(string id);

        /// <summary>
        /// Добавляет заданного пользователя в хранилище данных
        /// и возвращает идентификатор добавленного пользователя.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Уникальный идентификатор пользователя.</returns>
        Task<IdentityResult> AddUser(Models.User.User user);

        /// <summary>
        /// Обновляет информацию заданного пользователя в хранилище данных.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns> Task </returns>
        Task UpdateUser(Models.User.User user);

        /// <summary>
        /// Удаляет пользователя с заданным идентификатором
        /// из хранилища данных.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns> Task </returns>
        Task DeleteUser(string id);

        /// <summary>
        /// После добавление пользователя в репозитарий 
        /// генерирует ссылку, по которой пользователь
        /// в случае получения уведомлении об активации, может 
        /// активировать аккаунт.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Ссылку для активации аккаунта.</returns>
        string CreateConfirmationLink(Models.User.User user);

        /// <summary>
        /// Проверяет наличие пользователя в хранилище данных
        /// соответствующего заданному фильтру.
        /// </summary>
        /// <param name="filter">Лямбда-выражение определяющее фильтр для поиска пользователя.</param>
        /// <returns>Возвращает <see langword="true"/>, если пользователь существует в хранилище данных.</returns>
        bool UserExists(Expression<Func<Models.User.User, bool>> filter);
    }
}
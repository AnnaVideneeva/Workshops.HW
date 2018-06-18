using AutoMapper;
using Rocket.BL.Common.Services.User;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Identity;
using Rocket.Web.Attributes;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Rocket.Web.Controllers.User
{
    /// <summary>
    /// Контроллер WebApi работы с пользователями.
    /// </summary>
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly RocketUserManager _rocketUserManagerService;
        private readonly RockeRoleManager _rolemanager;
        private readonly IUserManagementService _userManagementService;

        public UsersController(
            RocketUserManager rocketUserManagerService, RockeRoleManager rolemanager, IUserManagementService userNativeManagementService)
        {
            _rocketUserManagerService = rocketUserManagerService;
            _rolemanager = rolemanager;
            _userManagementService = userNativeManagementService;

        }

        /// <summary>
        /// Возвращает всех пользователей.
        /// </summary>
        /// <returns>Все пользователи хранилища данных.</returns>
        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllUsers()
        {
            var users = _userManagementService.GetAllUsers();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        /// <summary>
        /// Возвращает пользователей для пейджинга.
        /// </summary>
        /// <param name="pageSize">Количество сведений о пользователях, выводимых на страницу.</param>
        /// <param name="pageNumber">Номер выводимой страницы со сведениями о пользователях.</param>
        /// <returns>Коллекция пользователей для пейджинга.</returns>
        [HttpGet]
        [Route("new/page_{pageNumber:int:min(1)}")]
        public IHttpActionResult GetUsersPage(int pageNumber, int pageSize = 5)
        {
            var users = _userManagementService.GetUsersPage(pageSize, pageNumber);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        /// <summary>
        /// Возвращает пользователя с конкретным
        /// уникальным идентификатором.
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя.</param>
        /// <returns>Пользователь хранилища.</returns>
        [HttpGet]
        [Route("{id:int:min(1)}")]
        public IHttpActionResult GetUserById(string id)
        {
            var user = _userManagementService.GetUser(id);

            return user == null ? (IHttpActionResult)NotFound() : Ok(user);
        }

        /// <summary>
        /// Регистрирует нового пользователя.
        /// </summary>
        /// <param name="user">Данные экземпляра пользователя.</param>
        /// <returns>Пользователь хранилища.</returns>
        [HttpPost]
        [Route("add")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Model is not valid", typeof(string))]
        [SwaggerResponse(HttpStatusCode.Created, "New model description", typeof(BL.Common.Models.User.User))]
        public async Task<IHttpActionResult> AddUser([FromBody] BL.Common.Models.User.User user)
        {
            //if (user == null)
            //{
            //    return BadRequest("User can not be empty");
            //}

            //var result =  _userManagementService.AddUser(user);

            //if (result.IsCompleted)
            //{
            //    var userId = await result;
            //    return Ok(userId);
            //}
            //var dbUser = Mapper.Map<DbUser>(user);

            //var dbUserProfile = new DbUserProfile()
            //{
            //    Email = new Collection<DbEmail>()
            //        {
            //            new DbEmail()
            //            {
            //                Name = "",
            //            }
            //        },
            //};

            //dbUser.DbUserProfile = dbUserProfile;

            await _rocketUserManagerService.CreateAsync(
                new DbUser()
                {
                    Email = user.Login,
                    UserName = user.Login,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DbUserProfile = new DbUserProfile()
                    {
                        Email = new List<DbEmail>()
                        {
                            new DbEmail()
                            {
                                Name = user.Login
                            }
                        }
                    }
                },
                user.Password).ConfigureAwait(false);

            return Ok();

            //var result = await _rocketUserManagerService.FindByNameAsync(user.Login).ConfigureAwait(false);

            //if (result != null)
            //{
            //    return BadRequest("User exists");
            //}

            //var dbRole = await _rolemanager.FindByNameAsync("administrator").ConfigureAwait(false);
            //var dbUserProfile = new DbUserProfile()
            //{
            //    Email = new Collection<DbEmail>()
            //        {
            //            new DbEmail()
            //            {
            //                Name = "emptyEmail",
            //            }
            //        },
            //};

            //var dbUser = Mapper.Map<DbUser>(user);
            //dbUser.DbUserProfile = dbUserProfile;

            //await _rocketUserManagerService.CreateAsync(dbUser).ConfigureAwait(false);

            //await _rocketUserManagerService
            //    .AddToRoleAsync(dbUser.Id, "user").ConfigureAwait(false);

            //return Ok();
        }

        /// <summary>
        /// Обновляет пользователя.
        /// </summary>
        /// <param name="user">Пользователь для обновления.</param>
        /// <returns>Сведения об обновлении пользователя.</returns>
        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdateUser([FromBody]BL.Common.Models.User.User user)
        {
            _userManagementService.UpdateUser(user);

            return new StatusCodeResult(HttpStatusCode.NoContent, Request);
        }

        /// <summary>
        /// Удаление пользователя с конкретным уникальным
        /// идентификатором.
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя.</param>
        /// <returns>Сведения об удалении.</returns>
        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public IHttpActionResult DeleteUserById(string id)
        {
            var usersCount = _userManagementService.GetAllUsers().Count;

            if (Convert.ToInt32(id) > usersCount)
            {
                return BadRequest("User id invalid");
            }

            _userManagementService.DeleteUser(id);

            return Ok($"User with id = {id} successfully deleted");
        }

        /// <summary>
        /// Удаление пользователя по его модели.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Сведения об удалении.</returns>
        [HttpDelete]
        public IHttpActionResult DeleteUserByModel([FromBody]BL.Common.Models.User.User user)
        {
            var usersLogin = user.Login;

            if (!_userManagementService.UserExists(f => f.Login == usersLogin))
            {
                return BadRequest("User invalid");
            }

            _userManagementService.DeleteUser(user.Id);

            return Ok($"User with id = {user.Id} successfully deleted");

            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.DbModels.Identity;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Identity;
using Claim = System.IdentityModel.Claims.Claim;

namespace Rocket.Web.Controllers
{
    [RoutePrefix("debug")]
    public class DebugController : ApiController
    {
        private readonly RocketUserManager _usermanager;
        private readonly RockeRoleManager _rolemanager;

        public DebugController(RocketUserManager usermanager, RockeRoleManager rolemanager)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }

        [Route("users/create")]
        [HttpGet]
        public async Task<IHttpActionResult> CreateUsers()
        {
            await _rolemanager.CreateAsync(new DbRole() { Name = "administrator" });
            await _rolemanager.CreateAsync(new DbRole() { Name = "user" });

            await _usermanager.CreateAsync(
                new DbUser()
                {
                    EmailConfirmed = true,
                    Email = "adminuser@gmail.com",
                    PhoneNumber = "+375221133654",
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = "adminUser",
                    FirstName = "Иван",
                    LastName = "Иванов",

                    DbUserProfile = new DbUserProfile()
                    {
                        Email = new Collection<DbEmail>()
                        {
                            new DbEmail()
                            {
                                Name = "secondmail@gmail.com",
                            }
                        },
                    },
                },
                "security").ConfigureAwait(false);

            await _usermanager.CreateAsync(
                new DbUser()
                {
                    EmailConfirmed = true,
                    Email = "userfirst@gmail.com",
                    PhoneNumber = "+375221159654",
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = "firstUser",
                    FirstName = "Петр",
                    LastName = "Петров",

                    DbUserProfile = new DbUserProfile()
                    {
                        Email = new Collection<DbEmail>()
                        {
                            new DbEmail()
                            {
                                Name = "lastemail@gmail.com",
                            }
                        },
                    },
                },
                "password").ConfigureAwait(false);

            await _usermanager.CreateAsync(
                new DbUser()
                {
                    EmailConfirmed = true,
                    Email = "second@gmail.com",
                    PhoneNumber = "+375221975854",
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = "secondUser",
                    FirstName = "Кирил",
                    LastName = "Булатов",

                    DbUserProfile = new DbUserProfile()
                    {
                        Email = new Collection<DbEmail>()
                        {
                            new DbEmail()
                            {
                                Name = "kiril@gmail.com",
                            }
                        },
                    },
                },
                "password2").ConfigureAwait(false);

            await _usermanager
                .AddToRoleAsync(_usermanager.FindByName("adminUser").Id, "administrator")
                .ConfigureAwait(false);
            await _usermanager
                .AddToRoleAsync(_usermanager.FindByName("firstUser").Id, "user")
                .ConfigureAwait(false);
            await _usermanager
                .AddToRoleAsync(_usermanager.FindByName("secondUser").Id, "user")
                .ConfigureAwait(false);

            return Ok();
        }

        public Task<IHttpActionResult> AddClaims() //async
        {
            //var user = _usermanager.FindByName("secondUser");
            //var claim1 = new Claim("permission", "permission", "read");

            //var userid = await _usermanager.FindByIdAsync(user.Id).ConfigureAwait(false);
            //await _usermanager.AddClaimAsync(userid, claim1).ConfigureAwait(false);

            //return Ok();

            throw new NotImplementedException();
        }
    }
}

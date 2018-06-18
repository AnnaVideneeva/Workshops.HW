//using System;
//using System.Collections.Generic;
//using AutoMapper;
//using Common.Logging;
//using FluentAssertions;
//using Moq;
//using NUnit.Framework;
//using Rocket.BL.Common.Models.UserRoles;
//using Rocket.BL.Services.UserServices;
//using Rocket.BL.Tests.ReleaseList.FakeData;
//using Rocket.DAL.Common.DbModels.Identity;
//using Rocket.DAL.Common.DbModels.ReleaseList;
//using Rocket.DAL.Common.Repositories.IDbUserRoleRepository;
//using Rocket.DAL.Common.UoW;

//namespace Rocket.BL.Tests.UserRoles
//{
//    [TestFixture]
//    public class PermissionServiceTest
//    {
//        private List<DbPermission> _fakeDbPermission;
//        private List<DbRole> _fakeDbRole;
//        private PermissionManagerService _pms;
//        private RoleService _rms;

//        [OneTimeSetUp]
//        public void SetupParam()
//        {
//            Mapper.Reset();
//            Mapper.Initialize(cfg =>
//            {
//                cfg.AddProfiles("Rocket.BL.Common");
//            });

//            _fakeDbPermission = new List<DbPermission>()
//            {
//                new DbPermission(){Id = 1, ValueName = "CorrectList", Description = "Корректировка ленты"},
//                new DbPermission(){Id = 2, ValueName = "Admin", Description = "Адмитнистратор"},
//                new DbPermission(){Id = 3, ValueName = "Guist", Description = "Гость"},
//                new DbPermission(){Id = 4, ValueName = "User", Description = "Пользователь"},
//                new DbPermission(){Id = 5, ValueName = "Donat", Description = "Донат"}
//            };

//            _fakeDbRole = new List<DbRole>()
//            {
//                new DbRole() { Id = 1,  Name = "Admin", Permissions = new List<DbPermission>()},
//                new DbRole() { Id = 2,  Name = "User", Permissions = new List<DbPermission>()},
//                new DbRole() { Id = 3,  Name = "Guist", Permissions = new List<DbPermission>()}
//            };

//            _fakeDbRole[0].Permissions.Add(_fakeDbPermission[0]);
//            _fakeDbRole[1].Permissions.Add(_fakeDbPermission[1]);
//            _fakeDbRole[2].Permissions.Add(_fakeDbPermission[2]);
//            _fakeDbRole[0].Permissions.Add(_fakeDbPermission[3]);
//            _fakeDbRole[1].Permissions.Add(_fakeDbPermission[4]);

//            var mockDbPermissionRepository = new Mock<IDbPermissionRepository>();

//            mockDbPermissionRepository.Setup(mock => mock.GetById(It.IsAny<int>())).Returns((int id) =>
//                _fakeDbPermission.Find(f => f.Id == id)
//            );
//            mockDbPermissionRepository.Setup(mock => mock.Insert(It.IsAny<DbPermission>())).Callback((DbPermission f) =>
//                _fakeDbPermission.Add(f)
//            );
//            mockDbPermissionRepository.Setup(mock => mock.Update(It.IsAny<DbPermission>())).Callback((DbPermission f) =>
//                _fakeDbPermission.Find(d => d.Id == f.Id).ValueName = f.ValueName
//            );
//            mockDbPermissionRepository.Setup(mock => mock.Delete(It.IsAny<int>())).Callback((int id) =>
//                _fakeDbPermission.Remove(_fakeDbPermission.Find(f => f.Id == id))
//            );

//            var mockDbRoleRepository = new Mock<IDbRoleRepository>();
//            mockDbRoleRepository.Setup(mock => mock.GetById(It.IsAny<int>())).Returns((int id) =>
//                _fakeDbRole.Find(f => f.Id == id)
//            );

//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            var mockLogger = new Mock<ILog>();

//            mockUnitOfWork.Setup(mock => mock.PermissionRepository).Returns(() => mockDbPermissionRepository.Object);
//            mockUnitOfWork.Setup(mock => mock.RoleRepository).Returns(() => mockDbRoleRepository.Object);

//            _pms = new PermissionManagerService(mockUnitOfWork.Object);
//            _rms = new RoleService(mockUnitOfWork.Object, mockLogger.Object);
//        }

//        [Test, Order(1)]
//        public void PermissionToRoleAdd()
//        {
//            _pms.AddPermissionToRole(2, 3);
//            var actualPermission = _fakeDbRole[1].Permissions;
//            actualPermission.Should().HaveCount(3);
//        }

//        [Test, Order(2)]
//        public void PermissionToRoleRemove()
//        {
//            _pms.RemovePermissionFromRole(2, 3);
//            var actualPermission = _fakeDbRole[1].Permissions;
//            actualPermission.Should().HaveCount(2);
//        }

//        [Test, Order(3)]
//        public void PermissionToRoleInsert()
//        {
//            Permission p = new Permission() { PermissionId = 6, Description = "Correct User", ValueName = "Корректировка пользователей" };
//            _pms.Insert(p);
//            var actualPermission = _fakeDbPermission.Count;
//            actualPermission.Should().Be(6);
//        }

//        [Test, Order(4)]
//        public void PermissionToRoleUpdate()
//        {
//            Permission p = new Permission() { PermissionId = 6, Description = "Correct User", ValueName = "Корректировка_пользователей" };
//            _pms.Update(p);
//            var actualPermission = _fakeDbPermission[5].ValueName;
//            actualPermission.Should().Be("Корректировка_пользователей");
//        }

//        [Test, Order(5)]
//        public void PermissionToRoleGetById()
//        {
//            Permission p = _pms.GetById(6);

//            var actualPermission = p.ValueName;
//            actualPermission.Should().Be("Корректировка_пользователей");
//        }

//        [Test, Order(6)]
//        public void PermissionToRoleDelete()
//        {
//            _pms.Delete(5);
//            var actualPermission = _fakeDbPermission.Count;
//            actualPermission.Should().Be(5);
//        }
//    }
//}
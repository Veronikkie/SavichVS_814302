using System;
using System.Threading.Tasks;
using AutoMapper;
using LAMS.DataAccess.Common.Models.Users;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.DataAccess.Common.Repositories.UserForm;
using LAMS.DataAccess.Contexts;
using LAMS.DataAccess.Repositories.UserForm;
using LAMS.DataAccess.Repositories.Users;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Services.Admin;
using LAMS.Logic.Services.UserForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LAMS.Logic.Unit
{
    [TestClass]
    public class AdminServiceTests
    {
        private AdminService adminService;
        private Mock<IAdminRepository> adminRepository;
        private Mock<IMapper> _mapper;

        [TestInitialize]
        public void Init()
        {
            _mapper = new Mock<IMapper>();
            adminRepository = new Mock<IAdminRepository>();
        }

        [TestMethod]
        public void AddProgLangAsync_ShouldReturnNull_IfProgLangNotAvailable()
        {
            var testProgLang = new ProgLangBLL
            {
                ProgLang = "TestProgLang"
            };

            var testProgLangDb = new ProgLangDb { ProgLang = testProgLang.ProgLang };

            adminRepository.Setup(a => a.IsProgLangAvailable(testProgLang.ProgLang)).Returns(Task.FromResult(false));
            _mapper.Setup(m => m.Map<ProgLangDb>(testProgLang))
                        .Returns(testProgLangDb);

            adminRepository.Setup(u => u.AddProgLangAsync(testProgLangDb))
                                    .Returns(Task.FromResult("1"));

            adminService = new AdminService(adminRepository.Object, _mapper.Object);

            var id = adminService.AddProgLangAsync(testProgLang).GetAwaiter().GetResult();

            Assert.IsNull(id);
        }

        [TestMethod]
        public void AddPersonalInfoAsync_ThrowException_IfPassingObjectNull()
        {
            adminRepository.Setup(a => a.IsProgLangAvailable("TestProgLang")).Returns(Task.FromResult(true));
            adminService = new AdminService(adminRepository.Object, _mapper.Object);

            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await adminService.AddProgLangAsync(null));
        }

        [TestMethod]
        public void AddProgLangAsync_ShouldReturnId_IfProgLangAvailable()
        {
            var testProgLang = new ProgLangBLL
            {
                ProgLang = "TestProgLang"
            };

            var testProgLangDb = new ProgLangDb { ProgLang = testProgLang.ProgLang };

            adminRepository.Setup(a => a.IsProgLangAvailable(testProgLang.ProgLang)).Returns(Task.FromResult(true));
            _mapper.Setup(m => m.Map<ProgLangDb>(testProgLang))
                        .Returns(testProgLangDb);

            adminRepository.Setup(u => u.AddProgLangAsync(testProgLangDb))
                                    .Returns(Task.FromResult("1"));

            adminService = new AdminService(adminRepository.Object, _mapper.Object);

            var id = adminService.AddProgLangAsync(testProgLang).GetAwaiter().GetResult();

            Assert.AreEqual(id, "1");
        }
    }
}

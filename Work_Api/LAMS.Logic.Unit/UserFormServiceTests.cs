using System;
using System.Threading.Tasks;
using AutoMapper;
using LAMS.DataAccess.Common.Models.Users;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.UserForm;
using LAMS.DataAccess.Contexts;
using LAMS.DataAccess.Repositories.UserForm;
using LAMS.DataAccess.Repositories.Users;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Services.UserForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LAMS.Logic.Unit
{
    [TestClass]
    public class UserFormServiceTests
    {
        private UserFormService userFormService;
        private Mock<IUserFormRepository> userFormRepository;
        private UserRepository userRepository;
        private Mock<IMapper> _mapper;

        [TestInitialize]
        public void Init()
        {
            _mapper = new Mock<IMapper>();
            userFormRepository = new Mock<IUserFormRepository>();
        }

        [TestMethod]
        public void AddPersonalInfoAsync_ThrowException_IfPassingObjectNull()
        {
            userFormService = new UserFormService(userFormRepository.Object, _mapper.Object);
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userFormService.AddPersonalInfoAsync(null));
        }

        [TestMethod]
        public void AddPersonalInfoAsync_ShouldReturnId()
        {
            var testPersonal = new PersonalInfoBLL
            {
                Name = "Test",
                Date = DateTime.Now,
                UserId = "3627597f-7d75-4134-8ea2-6071a776e5eb"
            };

            var testPersonalDb = new PersonalInfoDb { Name = testPersonal.Name, Date = testPersonal.Date, UserId = testPersonal.UserId };

            _mapper.Setup(m => m.Map<PersonalInfoDb>(testPersonal))
                        .Returns(testPersonalDb);

            userFormRepository.Setup(u => u.AddPersonalInfoAsync(testPersonalDb))
                                    .Returns(Task.FromResult("1"));
            userFormService = new UserFormService(userFormRepository.Object, _mapper.Object);

            var id = userFormService.AddPersonalInfoAsync(testPersonal).GetAwaiter().GetResult();

            _mapper.Verify(m => m.Map<PersonalInfoDb>(testPersonal));

            userFormRepository.Verify(u => u.AddPersonalInfoAsync(testPersonalDb), Times.Once());

            Assert.AreEqual(id, "1");
        }

        [TestMethod]
        public void AddEducationAsync_ThrowException_IfPassingObjectNull()
        {
            userFormService = new UserFormService(userFormRepository.Object, _mapper.Object);
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userFormService.AddEducationAsync(null));
        }

        [TestMethod]
        public void AddEducationAsync_ShouldReturnId()
        {
            var testEducation = new EducationBLL
            {
                PersonalInfoId = Guid.NewGuid().ToString(),
                End = 1
            };

            var testEducationDb = new EducationDb { PersonalInfoId = testEducation.PersonalInfoId, End = testEducation.End };

            _mapper.Setup(m => m.Map<EducationDb>(testEducation))
                        .Returns(testEducationDb);

            userFormRepository.Setup(u => u.AddEducationAsync(testEducationDb))
                                    .Returns(Task.FromResult("1"));
            userFormService = new UserFormService(userFormRepository.Object, _mapper.Object);

            var id = userFormService.AddEducationAsync(testEducation).GetAwaiter().GetResult();

            _mapper.Verify(m => m.Map<EducationDb>(testEducation));

            userFormRepository.Verify(u => u.AddEducationAsync(testEducationDb), Times.Once());

            Assert.AreEqual(id, "1");
        }

        [TestMethod]
        public void AddLanguageAsync_ThrowException_IfPassingObjectNull()
        {
            userFormService = new UserFormService(userFormRepository.Object, _mapper.Object);
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userFormService.AddLanguageAsync(null));
        }

        [TestMethod]
        public void AddLanguageAsync_ShouldReturnId()
        {
            var testEducation = new LanguageBLL
            {
                PersonalInfoId = Guid.NewGuid().ToString(),
            };

            var testEducationDb = new LanguageDb { PersonalInfoId = testEducation.PersonalInfoId };

            _mapper.Setup(m => m.Map<LanguageDb>(testEducation))
                        .Returns(testEducationDb);

            userFormRepository.Setup(u => u.AddLanguageAsync(testEducationDb))
                                    .Returns(Task.FromResult("1"));
            userFormService = new UserFormService(userFormRepository.Object, _mapper.Object);

            var id = userFormService.AddLanguageAsync(testEducation).GetAwaiter().GetResult();

            _mapper.Verify(m => m.Map<LanguageDb>(testEducation));

            userFormRepository.Verify(u => u.AddLanguageAsync(testEducationDb), Times.Once());

            Assert.AreEqual(id, "1");
        }

        [TestMethod]
        public void AddExperienceAsync_ThrowException_IfPassingObjectNull()
        {
            userFormService = new UserFormService(userFormRepository.Object, _mapper.Object);
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userFormService.AddExperienceAsync(null));
        }

        [TestMethod]
        public void AddExperienceAsync_ShouldReturnId()
        {
            var testExperiance = new ExperienceBLL
            {
                PersonalInfoId = Guid.NewGuid().ToString(),
            };

            var testExperianceDb = new ExperienceDb { PersonalInfoId = testExperiance.PersonalInfoId };

            _mapper.Setup(m => m.Map<ExperienceDb>(testExperiance))
                        .Returns(testExperianceDb);

            userFormRepository.Setup(u => u.AddExperienceAsync(testExperianceDb))
                                    .Returns(Task.FromResult("1"));
            userFormService = new UserFormService(userFormRepository.Object, _mapper.Object);

            var id = userFormService.AddExperienceAsync(testExperiance).GetAwaiter().GetResult();

            _mapper.Verify(m => m.Map<ExperienceDb>(testExperiance));

            userFormRepository.Verify(u => u.AddExperienceAsync(testExperianceDb), Times.Once());

            Assert.AreEqual(id, "1");
        }
    }
}

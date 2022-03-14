using LAMS.DataAccess.Common.DTO;
using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Repositories.UserForm
{
  public  interface IUserFormRepository : IDisposable
    {

        Task<string> AddPersonalInfoAsync(PersonalInfoDb info);
        Task<string> AddEducationAsync(EducationDb info);
        Task<string> AddLanguageAsync(LanguageDb info);
        Task<string> AddExperienceAsync(ExperienceDb info);
        Task<string> AddUserProgLang(UserProgLangDb info);


        Task<IEnumerable<PersonalInfoDb>> GetUsersForm();
        Task<IEnumerable<PersonalInfoDb>> GetUsersFormSee();
        Task<IEnumerable<PersonalInfoDb>> GetUsersFormApprove();
        Task<IEnumerable<PersonalInfoDb>> GetUsersFormReject();


        Task<PersonalInfoDb> GetPersonalInfo(string UserId);
        Task<EducationDb> GetEducationInfo(string UserId);
        Task<LanguageDb> GetLanguageInfo(string UserId);
        Task<ExperienceDb> GetExperienceInfo(string UserId);
        Task<IEnumerable<UserProgLangDb>> GetUserProgLangInfo(string UserId);


        Task<int> SeeForm(string id);
        Task<int> Approve(string id);
        Task<int> Reject(string id);


        Task<IEnumerable<PersonalInfoDb>> GetUserStatus(string id);

        Task<int> AddTextAsync(DocumentDb document);
        Task<IEnumerable<DocumentDTO>> GetNamesOfTextsByIdAsync(string UserId);
        DocumentDb GetTextById(int id);


        Task<int> AddQuestion(QuestionDb info);
        Task<IEnumerable<QuestionDb>> GetQuestion(string Id);


        Task<int> AddAnswer(QuestionDb question);
    }
}

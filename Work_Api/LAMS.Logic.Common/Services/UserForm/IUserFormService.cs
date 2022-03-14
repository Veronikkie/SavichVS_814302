using LAMS.DataAccess.Common.Models.Work;
using LAMS.Logic.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Services.UserForm
{
    public interface IUserFormService : IDisposable
    {

        Task<string> AddPersonalInfoAsync(PersonalInfoBLL info);
        Task<string> AddEducationAsync(EducationBLL info);
        Task<string> AddLanguageAsync(LanguageBLL info);
        Task<string> AddExperienceAsync(ExperienceBLL info);
        Task<string> AddUserProgLang(UserProgLangBLL info);

        Task<IEnumerable<PersonalInfoBLL>> GetUsersForm();
        Task<IEnumerable<PersonalInfoBLL>> GetUsersFormSee();
        Task<IEnumerable<PersonalInfoBLL>> GetUsersFormApprove();
        Task<IEnumerable<PersonalInfoBLL>> GetUsersFormReject();

        Task<PersonalInfoBLL> GetPersonalInfo(string UserId);
        Task<EducationBLL> GetEducationInfo(string UserId);
        Task<LanguageBLL> GetLanguageInfo(string UserId);
        Task<ExperienceBLL> GetExperienceInfo(string UserId);
        Task<IEnumerable<UserProgLangBLL>> GetUserProgLangInfo(string UserId);

        Task<int> SeeForm(string id);
        Task<int> Approve(string id);
        Task<int> Reject(string id);

        Task<IEnumerable<PersonalInfoBLL>> GetUserStatus(string id);

        Task<int> AddTextAsync(DocumentBLL document);
        Task<IEnumerable<DocumentBLL>> GetNamesOfTextsAsync(string UserId);
        DocumentDb GetTextById(int id);

        Task<int> AddQuestion(QuestionBLL info);

        Task<IEnumerable<QuestionBLL>> GetQuestion(string Id);
        Task<int> AddAnswer(QuestionBLL question);
    }
}

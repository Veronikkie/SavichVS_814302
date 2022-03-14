using AutoMapper;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.UserForm;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.UserForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Services.UserForm
{
    public class UserFormService : IUserFormService
    {
        private IMapper _mapper;
        private IUserFormRepository _repo;

        public UserFormService(IUserFormRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<string> AddPersonalInfoAsync(PersonalInfoBLL info)
        {
            try
            {
                var id = await _repo.AddPersonalInfoAsync(_mapper.Map<PersonalInfoDb>(info)).ContinueWith(t => t.Result);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> AddEducationAsync(EducationBLL info)
        {
            try
            {
                var id = await _repo.AddEducationAsync(_mapper.Map<EducationDb>(info)).ContinueWith(t => t.Result);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> AddLanguageAsync(LanguageBLL info)
        {
            try
            {
                var id = await _repo.AddLanguageAsync(_mapper.Map<LanguageDb>(info)).ContinueWith(t => t.Result);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> AddExperienceAsync(ExperienceBLL info)
        {
            try
            {
                var id = await _repo.AddExperienceAsync(_mapper.Map<ExperienceDb>(info)).ContinueWith(t => t.Result);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> AddUserProgLang(UserProgLangBLL info)
        {
            try
            {
                var id = await _repo.AddUserProgLang(_mapper.Map<UserProgLangDb>(info)).ContinueWith(t => t.Result);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PersonalInfoBLL>> GetUsersForm()
        {
            return await _repo.GetUsersForm()
                .ContinueWith(t => _mapper.Map<IEnumerable<PersonalInfoBLL>>(t.Result));
        }

        public async Task<IEnumerable<PersonalInfoBLL>> GetUsersFormSee()
        {
            return await _repo.GetUsersFormSee()
                .ContinueWith(t => _mapper.Map<IEnumerable<PersonalInfoBLL>>(t.Result));
        }

        public async Task<IEnumerable<PersonalInfoBLL>> GetUsersFormApprove()
        {
            return await _repo.GetUsersFormApprove()
                .ContinueWith(t => _mapper.Map<IEnumerable<PersonalInfoBLL>>(t.Result));
        }

        public async Task<IEnumerable<PersonalInfoBLL>> GetUsersFormReject()
        {
            return await _repo.GetUsersFormReject()
                .ContinueWith(t => _mapper.Map<IEnumerable<PersonalInfoBLL>>(t.Result));
        }

        public async Task<PersonalInfoBLL> GetPersonalInfo(string UserId)
        {
            return await _repo.GetPersonalInfo(UserId)
                .ContinueWith(t => _mapper.Map<PersonalInfoBLL>(t.Result));
        }

        public async Task<EducationBLL> GetEducationInfo(string UserId)
        {
            return await _repo.GetEducationInfo(UserId)
                .ContinueWith(t => _mapper.Map<EducationBLL>(t.Result));
        }

        public async Task<LanguageBLL> GetLanguageInfo(string UserId)
        {
            return await _repo.GetLanguageInfo(UserId)
                .ContinueWith(t => _mapper.Map<LanguageBLL>(t.Result));
        }

        public async Task<ExperienceBLL> GetExperienceInfo(string UserId)
        {
            return await _repo.GetExperienceInfo(UserId)
                .ContinueWith(t => _mapper.Map<ExperienceBLL>(t.Result));
        }

        public async Task<IEnumerable<UserProgLangBLL>> GetUserProgLangInfo(string UserId)
        {
            return await _repo.GetUserProgLangInfo(UserId)
                .ContinueWith(t => _mapper.Map<IEnumerable<UserProgLangBLL>>(t.Result));
        }

        public async Task<int> SeeForm(string id)
        {
            return await _repo.SeeForm(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
        }

        public async Task<int> Approve(string id)
        {
            return await _repo.Approve(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
        }

        public async Task<int> Reject(string id)
        {
            return await _repo.Reject(_mapper.Map<string>(id)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<PersonalInfoBLL>> GetUserStatus(string id)
        {
            return await _repo.GetUserStatus(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<PersonalInfoBLL>>(t.Result));
        }
        public async Task<int> AddTextAsync(DocumentBLL text)
        {
            return await _repo.AddTextAsync(_mapper.Map<DocumentDb>(text)).ContinueWith(t => t.Result);
        }
        public async Task<IEnumerable<DocumentBLL>> GetNamesOfTextsAsync(string UserId)
        {
            IEnumerable<DocumentBLL> textsInfo;

            textsInfo = await _repo.GetNamesOfTextsByIdAsync(UserId).ContinueWith(t => _mapper.Map<IEnumerable<DocumentBLL>>(t.Result));

            return textsInfo;
        }
        public DocumentDb GetTextById(int id)
        {
            return _repo.GetTextById(id);
        }

        public async Task<int> AddQuestion(QuestionBLL info)
        {
            try
            {
                var id = await _repo.AddQuestion(_mapper.Map<QuestionDb>(info)).ContinueWith(t => t.Result);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<QuestionBLL>> GetQuestion(string Id)
        {
            return await _repo.GetQuestion(Id)
                .ContinueWith(t => _mapper.Map<IEnumerable<QuestionBLL>>(t.Result));
        }

        public async Task<int> AddAnswer(QuestionBLL question)
        {
            return await _repo.AddAnswer(_mapper.Map<QuestionDb>(question)).ContinueWith(t => t.Result);
        }
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~DocumentService() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        void IDisposable.Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

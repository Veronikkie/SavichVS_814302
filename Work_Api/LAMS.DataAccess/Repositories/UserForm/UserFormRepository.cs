using LAMS.DataAccess.Common.DTO;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.UserForm;
using LAMS.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Repositories.UserForm
{
    public class UserFormRepository : IUserFormRepository
    {
        private readonly DocContext _context;

        public UserFormRepository(DocContext context) => _context = context;

        public async Task<string> AddPersonalInfoAsync(PersonalInfoDb info)
        {
            info.Id = Guid.NewGuid().ToString();
            info.CreateDate = DateTime.Now;
            info.Status = "New";
            _context.PersonalInfos.Add(info);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return info.Id;
        }
        public async Task<string> AddEducationAsync(EducationDb info)
        {
            info.Id = Guid.NewGuid().ToString();
            _context.Educations.Add(info);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return info.Id;
        }
        public async Task<string> AddLanguageAsync(LanguageDb info)
        {
            info.Id = Guid.NewGuid().ToString();
            _context.Languages.Add(info);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return info.Id;
        }

        public async Task<string> AddExperienceAsync(ExperienceDb info)
        {
            info.Id = Guid.NewGuid().ToString();
            _context.Experiences.Add(info);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return info.Id;
        }

        public async Task<string> AddUserProgLang(UserProgLangDb info)
        {
            info.Id = Guid.NewGuid().ToString();
            _context.UserProgLangs.Add(info);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return info.Id;
        }

        public async Task<IEnumerable<PersonalInfoDb>> GetUsersForm()
        {
            var info = await _context.PersonalInfos.Where(p => p.Status == "New").ToListAsync().ConfigureAwait(false);
            return info;
        }

        public async Task<IEnumerable<PersonalInfoDb>> GetUsersFormSee()
        {
            var info = await _context.PersonalInfos.Where(p => p.Status == "Seen").ToListAsync().ConfigureAwait(false);
            return info;
        }

        public async Task<IEnumerable<PersonalInfoDb>> GetUsersFormApprove()
        {
            var info = await _context.PersonalInfos.Where(p => p.Status == "Approved").ToListAsync().ConfigureAwait(false);
            return info;
        }
        public async Task<IEnumerable<PersonalInfoDb>> GetUsersFormReject()
        {
            var info = await _context.PersonalInfos.Where(p => p.Status == "Rejected").ToListAsync().ConfigureAwait(false);
            return info;
        }

        public async Task<PersonalInfoDb> GetPersonalInfo(string UserId)
        {
            var res = await _context.PersonalInfos.Where(p =>
                                     p.Id == UserId).FirstOrDefaultAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<EducationDb> GetEducationInfo(string UserId)
        {
            var res = await _context.Educations.Where(p =>
                                    p.PersonalInfoId == UserId).FirstOrDefaultAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<LanguageDb> GetLanguageInfo(string UserId)
        {
            var res = await _context.Languages.Where(p =>
                                    p.PersonalInfoId == UserId).FirstOrDefaultAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<ExperienceDb> GetExperienceInfo(string UserId)
        {
            var res = await _context.Experiences.Where(p =>
                                    p.PersonalInfoId == UserId).FirstOrDefaultAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<IEnumerable<UserProgLangDb>> GetUserProgLangInfo(string UserId)
        {
            var res = await _context.UserProgLangs.Where(p =>
                                     p.PersonalInfoId == UserId).ToListAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<int> SeeForm(string id)
        {
            var info = await _context.PersonalInfos.FirstOrDefaultAsync(p => p.Id == id && p.Status == "New").ConfigureAwait(false);

            info.Status = "Seen";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> Approve(string id)
        {
            var info = await _context.PersonalInfos.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Seen").ConfigureAwait(false);

            info.Status = "Approved";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> Reject(string id)
        {
            var info = await _context.PersonalInfos.FirstOrDefaultAsync(p => p.Id == id && p.Status == "Seen").ConfigureAwait(false);

            info.Status = "Rejected";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<PersonalInfoDb>> GetUserStatus(string id)
        {
            return await _context.PersonalInfos.Where(p =>
                                    p.UserId == id).ToListAsync().ConfigureAwait(false);
        }
        public async Task<int> AddTextAsync(DocumentDb document)
        {
            _context.Documents.Add(document);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return document.Id;
        }
        public async Task<IEnumerable<DocumentDTO>> GetNamesOfTextsByIdAsync(string UserId)
        {
            List<DocumentDTO> textsArchive = await _context.Documents
                .Where(text => text.PersonalInfoId == UserId && SqlFunctions.DataLength(text.Text) != 0 && !string.IsNullOrEmpty(text.Name))
                .OrderBy(t => t.Number)
                 .Select(m =>
                    new DocumentDTO
                    {
                        Id = m.Id,
                        Name = m.Name
                    })
                .ToListAsync();

            return textsArchive;
        }
        public DocumentDb GetTextById(int id)
        {
            return _context.Documents
                .FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<QuestionDb>> GetQuestion(string Id)
        {
            return await _context.Questions.Where(p =>
                                    p.PersonalInfoId == Id).ToListAsync().ConfigureAwait(false);
        }
        public async Task<int> AddQuestion(QuestionDb info)
        {
            _context.Questions.Add(info);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return info.Id;
        }

        public async Task<int> AddAnswer(QuestionDb question)
        {
            var questionInDb = await _context.Questions.FirstOrDefaultAsync(p => p.Id == question.Id).ConfigureAwait(false);
            questionInDb.Answer = question.Answer;

            var entry = _context.Entry(questionInDb);
            entry.CurrentValues.SetValues(questionInDb);
            entry.Property(p => p.Answer).IsModified = true;
            entry.Property(p => p.Id).IsModified = false;
            entry.Property(p => p.PersonalInfoId).IsModified = false;
            entry.Property(p => p.Question).IsModified = false;

            return await _context.SaveChangesAsync().ConfigureAwait(false);
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
        // ~DocumentRepository() {
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

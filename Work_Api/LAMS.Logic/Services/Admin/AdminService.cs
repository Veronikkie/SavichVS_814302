using AutoMapper;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Services.Admin
{
   public class AdminService : IAdminService
    {
        private IMapper _mapper;
        private IAdminRepository _repo;

        public AdminService(IAdminRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<string> AddProgLangAsync(ProgLangBLL info)
        {
            try
            {
                if (!await _repo.IsProgLangAvailable(info.ProgLang))
                {
                    // throws 409 conflict
                    return null;
                }
                var id = await _repo.AddProgLangAsync(_mapper.Map<ProgLangDb>(info)).ContinueWith(t => t.Result);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ProgLangBLL>> GetProgLangs()
        {
            return await _repo.GetProgLangs()
                .ContinueWith(t => _mapper.Map<IEnumerable<ProgLangBLL>>(t.Result));
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

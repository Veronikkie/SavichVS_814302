using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Repositories.Admin
{
  public  class AdminRepository : IAdminRepository
    {
        private readonly DocContext _context;

        public AdminRepository(DocContext context) => _context = context;

        public async Task<string> AddProgLangAsync(ProgLangDb info)
        {
   
            _context.ProgLangs.Add(info);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return info.ProgLang;
        }

        public async Task<IEnumerable<ProgLangDb>> GetProgLangs()
        {
            var info = await _context.ProgLangs.ToListAsync().ConfigureAwait(false);
            return info;
        }

        public async Task<bool> IsProgLangAvailable(string proglang)
        {
            return !(await _context.ProgLangs.AnyAsync(u => u.ProgLang == proglang).ConfigureAwait(false));
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

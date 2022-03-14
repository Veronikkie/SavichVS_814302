using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Repositories.Admin
{
  public  interface IAdminRepository : IDisposable
    {
        Task<string> AddProgLangAsync(ProgLangDb info);
        Task<IEnumerable<ProgLangDb>> GetProgLangs();


        Task<bool> IsProgLangAvailable(string proglang);
    }
}

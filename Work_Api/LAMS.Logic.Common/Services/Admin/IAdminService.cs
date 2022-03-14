using LAMS.Logic.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Services.Admin
{
   public interface IAdminService : IDisposable
    {
        Task<string> AddProgLangAsync(ProgLangBLL info);

        Task<IEnumerable<ProgLangBLL>> GetProgLangs();
    }
}

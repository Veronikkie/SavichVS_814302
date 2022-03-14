using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
   public class ProgLangDb
    {
        public int Id { get; set; }

        public string ProgLang { get; set; }


        public virtual ICollection<UserProgLangDb> UserProgLangs { get; set; }
    }
}

using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
  public  class UserProgLangDb
    {
        public string Id { get; set; }

        public string PersonalInfoId { get; set; }

        public virtual PersonalInfoDb PersonalInfos { get; set; }

        public int ProgLangId { get; set; }
        public virtual ProgLangDb ProgLangs { get; set; }

        public string Level { get; set; }
        public string Period { get; set; }
    }
}

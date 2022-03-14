using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
   public class UserProgLangBLL
    {

        public string Id { get; set; }

        public string PersonalInfoId { get; set; }

        public string ProgLangId { get; set; }
        public string ProgLangProgLang { get; set; }
        public virtual ProgLangBLL ProgLangs { get; set; }

        public string Level { get; set; }
        public string Period { get; set; }
        public string Status { get; set; }
    }
}

using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
    public class LanguageDb
    {
        public string Id { get; set; }

        public string PersonalInfoId { get; set; }

        public virtual PersonalInfoDb PersonalInfos { get; set; }

        public string English { get; set; }
        public string German { get; set; }
        public string French { get; set; }
        public string Spanish { get; set; }
        public string Chinese { get; set; }
        public string Arab { get; set; }
    }
}

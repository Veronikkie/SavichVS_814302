using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
  public  class ExperienceDb
    {

        public string Id { get; set; }

        public string PersonalInfoId { get; set; }

        public virtual PersonalInfoDb PersonalInfos { get; set; }

        public string Experience { get; set; }

    }
}

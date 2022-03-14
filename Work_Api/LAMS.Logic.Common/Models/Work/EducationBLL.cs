using LAMS.Logic.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
  public  class EducationBLL
    {
        public string Id { get; set; }

        public string PersonalInfoId { get; set; }

        public string Education { get; set; }

        public string EducationType { get; set; }

        public string Institution { get; set; }

        public string Faculty { get; set; }

        public string Speciality { get; set; }

        public int End { get; set; }

        public string AnotherInfo { get; set; }

    }
}

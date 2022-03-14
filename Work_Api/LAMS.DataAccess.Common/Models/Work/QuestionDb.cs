using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
   public class QuestionDb
    {
        public int Id { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }
        public string PersonalInfoId { get; set; }

        public virtual PersonalInfoDb PersonalInfo { get; set; }
    }
}

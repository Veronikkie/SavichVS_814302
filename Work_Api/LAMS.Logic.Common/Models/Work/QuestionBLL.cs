using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
  public  class QuestionBLL
    {
        public int Id { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }
        public string PersonalInfoId { get; set; }

    }
}

using LAMS.Logic.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
   public class PersonalInfoBLL
    {
        public string Id { get; set; }

        public string UserId { get; set; }

     //   public virtual User Users { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime Date { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public string MinSalary { get; set; }

        public string MaxSalary { get; set; }

        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
    }
}

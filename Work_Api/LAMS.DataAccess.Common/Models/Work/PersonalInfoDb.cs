using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
   public class PersonalInfoDb
    {
        
        public string Id { get; set; }

        public string UserId { get; set; } 
        
        public virtual UserDb Users { get; set; }

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


        public virtual ICollection<QuestionDb> Questions { get; set; }
        public virtual ICollection<EducationDb> Educations { get; set; }
        public virtual ICollection<LanguageDb> Languages { get; set; }
        public virtual ICollection<ExperienceDb> Experiences { get; set; }
        public virtual ICollection<UserProgLangDb> UserProgLangs { get; set; }
        public virtual ICollection<DocumentDb> Documents { get; set; }
    }
}

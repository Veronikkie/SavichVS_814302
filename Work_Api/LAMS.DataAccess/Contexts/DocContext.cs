
using LAMS.DataAccess.Common.Models.Users;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.ModelConfigurations.Auth;
using LAMS.DataAccess.ModelConfigurations.Work;
using System.Collections.Generic;
using System.Data.Entity;

namespace LAMS.DataAccess.Contexts
{
 
    public class DocContext : DbContext
    {
        public DocContext() : base("LLAConnection") { }
        public DocContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());



            modelBuilder.Configurations.Add(new PersonalInfoConfiguration());
            modelBuilder.Configurations.Add(new EducationConfiguration());
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            modelBuilder.Configurations.Add(new ExperienceConfiguration());
            modelBuilder.Configurations.Add(new ProgLangConfiguration());
            modelBuilder.Configurations.Add(new UserProgLangConfiguration());
            modelBuilder.Configurations.Add(new DocumentConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
        }
        public IDbSet<UserDb> Users { get; set; }

        public IDbSet<RoleDb> Roles { get; set; }


        public IDbSet<PersonalInfoDb> PersonalInfos { get; set; }
        public IDbSet<EducationDb> Educations { get; set; }
        public IDbSet<LanguageDb> Languages { get; set; }
        public IDbSet<ExperienceDb> Experiences { get; set; }
        public IDbSet<ProgLangDb> ProgLangs { get; set; }
        public IDbSet<UserProgLangDb> UserProgLangs { get; set; }
        public IDbSet<DocumentDb> Documents { get; set; }
        public IDbSet<QuestionDb> Questions { get; set; }


   
    }
}

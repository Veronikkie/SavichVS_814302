using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Work
{
  public  class QuestionConfiguration : EntityTypeConfiguration<QuestionDb>
    {
        public QuestionConfiguration()
        {
            ToTable("Question");

            HasKey(x => x.Id);

            HasRequired(m => m.PersonalInfo)
                    .WithMany(t => t.Questions)
                    .HasForeignKey(m => m.PersonalInfoId)
                    .WillCascadeOnDelete(false);


        }
    }
}

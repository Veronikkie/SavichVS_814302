using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Work
{
  public  class ExperienceConfiguration : EntityTypeConfiguration<ExperienceDb>
    {
        public ExperienceConfiguration()
        {
            ToTable("Experience");

            HasKey(x => x.Id);

            HasRequired(m => m.PersonalInfos)
                    .WithMany(t => t.Experiences)
                    .HasForeignKey(m => m.PersonalInfoId)
                    .WillCascadeOnDelete(false);

            Property(m => m.Experience).HasMaxLength(5000);
        }
    }
}

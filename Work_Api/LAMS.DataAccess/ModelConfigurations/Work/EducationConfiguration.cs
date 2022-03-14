using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Work
{
   public class EducationConfiguration : EntityTypeConfiguration<EducationDb>
    {
        public EducationConfiguration()
        {
            ToTable("Education");

            HasKey(x => x.Id);

            HasRequired(m => m.PersonalInfos)
                    .WithMany(t => t.Educations)
                    .HasForeignKey(m => m.PersonalInfoId)
                    .WillCascadeOnDelete(false);
        }
    }
}

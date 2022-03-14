using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Work
{
   public class LanguageConfiguration : EntityTypeConfiguration<LanguageDb>
    {
        public LanguageConfiguration()
        {
            ToTable("Language");

            HasKey(x => x.Id);

            HasRequired(m => m.PersonalInfos)
                    .WithMany(t => t.Languages)
                    .HasForeignKey(m => m.PersonalInfoId)
                    .WillCascadeOnDelete(false);
        }
    }
}
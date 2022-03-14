using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Work
{
   public class UserProgLangConfiguration : EntityTypeConfiguration<UserProgLangDb>
    {
        public UserProgLangConfiguration()
        {
            ToTable("UserProgLang");

            HasKey(x => x.Id);

            HasRequired(m => m.ProgLangs)
                    .WithMany(t => t.UserProgLangs)
                    .HasForeignKey(m => m.ProgLangId)
                    .WillCascadeOnDelete(false);

            HasRequired(m => m.PersonalInfos)
              .WithMany(t => t.UserProgLangs)
              .HasForeignKey(m => m.PersonalInfoId)
              .WillCascadeOnDelete(false);
        }
    }
}

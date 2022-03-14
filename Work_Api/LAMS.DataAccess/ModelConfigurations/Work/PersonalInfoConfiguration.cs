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
    public class PersonalInfoConfiguration : EntityTypeConfiguration<PersonalInfoDb>
    {
        public PersonalInfoConfiguration()
        {
            ToTable("PersonalInfo");

            HasKey(x => x.Id);

            HasRequired(m => m.Users)
                    .WithMany(t => t.PersonalInfos)
                    .HasForeignKey(m => m.UserId)
                    .WillCascadeOnDelete(false);
        }
    }
}

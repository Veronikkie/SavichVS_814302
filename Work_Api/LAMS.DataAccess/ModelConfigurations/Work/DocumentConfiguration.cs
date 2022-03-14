﻿using LAMS.DataAccess.Common.Models.Users;
using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Work
{
   public class DocumentConfiguration : EntityTypeConfiguration<DocumentDb>
    {
        public DocumentConfiguration()
        {
            ToTable("Documents");
            HasKey(x => x.Id);

            HasRequired(x => x.PersonalInfos)
                .WithMany(doc => doc.Documents)
                .HasForeignKey(x => x.PersonalInfoId)
                .WillCascadeOnDelete(false);
        }
    }
}

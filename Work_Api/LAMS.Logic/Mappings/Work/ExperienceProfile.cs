﻿using AutoMapper;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.Logic.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Mappings.Work
{
    class ExperienceProfile : Profile
    {
        public ExperienceProfile()
        {
            CreateMap<ExperienceBLL, ExperienceDb>().ReverseMap();
            CreateMap<ExperienceDb, ExperienceBLL>();
        }
    }
}


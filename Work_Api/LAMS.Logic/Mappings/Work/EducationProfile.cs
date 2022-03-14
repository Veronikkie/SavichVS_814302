using AutoMapper;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.Logic.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Mappings.Work
{
    public class EducationProfile : Profile
    {
        public EducationProfile()
        {
            CreateMap<EducationBLL, EducationDb>().ReverseMap();
            CreateMap<EducationDb, EducationBLL>();
        }
    }
}

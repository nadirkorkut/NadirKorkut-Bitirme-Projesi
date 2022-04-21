using AutoMapper;
using SiteManager.Business.DTOs;
using SiteManager.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.Business.AutoMapper.Profiles
{
    public class FlatProfile : Profile
    {
        public FlatProfile()
        {
            CreateMap<FlatDto,Flat>().ReverseMap();
            CreateMap<UpdateFlatDto,Flat>().ReverseMap();
            CreateMap<CreateFlatDto,Flat>().ReverseMap();
        }
    }
}

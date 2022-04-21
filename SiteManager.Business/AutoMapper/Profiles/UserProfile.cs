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
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto,User>().ReverseMap();
            CreateMap<LoginDto,User>().ReverseMap();
            CreateMap<RegisterDto,User>().ReverseMap();
        }
    }
}

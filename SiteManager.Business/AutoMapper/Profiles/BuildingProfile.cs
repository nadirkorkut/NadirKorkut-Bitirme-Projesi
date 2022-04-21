using AutoMapper;
using SiteManager.Business.DTOs;
using SiteManager.Domain.Concrete;

namespace SiteManager.Business.AutoMapper.Profiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<BuildingDto,Building>().ReverseMap();
        }
    }
}

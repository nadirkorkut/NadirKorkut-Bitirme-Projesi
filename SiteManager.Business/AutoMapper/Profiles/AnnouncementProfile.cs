using AutoMapper;
using SiteManager.Business.DTOs;
using SiteManager.Domain.Concrete;

namespace SiteManager.Business.AutoMapper.Profiles
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<AnnouncementDto,Announcement>().ReverseMap();
        }
    }
}

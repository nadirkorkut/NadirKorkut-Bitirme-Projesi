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
    public class ExpenseTypeProfile : Profile
    {
        public ExpenseTypeProfile()
        {
            CreateMap<ExpenseTypeDto,ExpenseType>().ReverseMap();
        }
    }
}

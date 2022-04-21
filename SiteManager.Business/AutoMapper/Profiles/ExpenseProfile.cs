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
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseDto,Expense>().ReverseMap();
            CreateMap<CreateExpenseDto,Expense>().ReverseMap();
            CreateMap<UpdateExpenseDto,Expense>().ReverseMap();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteManager.Business.Abstract;
using SiteManager.Business.Concrete;
using SiteManager.DataAccess.Abstract;
using SiteManager.DataAccess.Concrete;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<SiteManagerDbContext>();

            serviceCollection.AddScoped<IAnnouncementRepository, EfAnnouncementRepository>();
            serviceCollection.AddScoped<IBuildingRepository, EfBuildingReposiyory>();
            serviceCollection.AddScoped<IExpenseRepository, EfExpenseRepository>();
            serviceCollection.AddScoped<IExpenseTypeRepository,EfExpenseTypeRepository>();
            serviceCollection.AddScoped<IFlatRepository, EfFlatRespository>();
            serviceCollection.AddScoped<IMessageRepository, EfMessageRepository>();
            serviceCollection.AddScoped<IRoleRepository, EfRoleRepository>();
            serviceCollection.AddScoped<IUserRepository, EfUserRepository>();

            serviceCollection.AddScoped<IAnnouncementService, AnnouncementManager>();
            serviceCollection.AddScoped<IBuildingService,BuildingManager>();
            serviceCollection.AddScoped<IExpenseService,ExpenseManager>();
            serviceCollection.AddScoped<IExpenseTypeService,ExpenseTypeManager>();
            serviceCollection.AddScoped<IFlatService,FlatManager>();
            serviceCollection.AddScoped<IMessageService,MessageManager>();
            serviceCollection.AddScoped<IUserService,UserManager>();

            serviceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

            return serviceCollection;
        }
    }
}

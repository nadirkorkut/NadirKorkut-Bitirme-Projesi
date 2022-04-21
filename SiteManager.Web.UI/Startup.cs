using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SiteManager.Business.Extensions;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.Domain.Concrete;

namespace SiteManager.Web.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SiteManagerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.LoadMyService();
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<SiteManagerDbContext>().AddDefaultTokenProviders();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
           services.AddAutoMapper(typeof(Startup));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/ResponseMiddleware/PageNotFound";
                    await next();
                }
            });

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 302)
                {
                    context.Request.Path = "/ResponseMiddleware/AccessDenied";
                    await next();
                }
            });

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 500)
                {
                    context.Request.Path = "/ResponseMiddleware/InternalServerError";
                    await next();
                }
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}/{id?}");
            });
        }
    }
}

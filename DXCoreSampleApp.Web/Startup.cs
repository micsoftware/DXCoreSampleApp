using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DXCoreSampleApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DXCoreSampleApp.Common.Data;
using Microsoft.Extensions.Configuration;
using DXCoreSampleApp.Service.Contacts;
using DXCoreSampleApp.Identity;
using Microsoft.AspNetCore.Identity;

namespace DXCoreSampleApp.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //var connectringString = Configuration.GetSection("ConnectionStrings:DevelopmentConnection").Value;
            var connectringString = Configuration.GetConnectionString("DevelopmentConnection");
            services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(connectringString));

            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectringString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<IContactService, ContactService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger,
            DatabaseContext context)
        {
            logger.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //context.EnsureSeedDataForContext();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();
            app.UseFileServer();
            app.UseStatusCodePages();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

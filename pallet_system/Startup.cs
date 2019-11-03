using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pallet_system.DAL;
using pallet_system.Interfaces;
using pallet_system.Models;
using pallet_system.Providers;
using pallet_system.Repository;

namespace pallet_system
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
            services.AddDbContext<PalletSystemContext>(options =>
            {
                options.UseFirebird(Configuration.GetConnectionString("Pallet_System"));
            });
            services.AddDbContext<AccountContext>(options =>
            {
                options.UseFirebird(Configuration.GetConnectionString("AccountDB"));
            });

            services.AddControllersWithViews();

            services.AddTransient<IRepository<ProgramData>, ProgramDataRepository>();
            services.AddTransient<IRepository<ProgramData>, ProgramDataRepository>();
            services.AddTransient<IRepository<ProgramInfo>, ProgramInfoRepository>();
            services.AddTransient<IRepository<Status>, StatusRepository>();
            services.AddTransient<IRepository<Pallet>, PalletRepository>();
            services.AddTransient<IRepository<VirtualPallet>, VirtualPalletRepository>();
            services.AddTransient<IRepository<StepData>, StepDataRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Pallet}/{action=List}/{id?}");
            });
        }
    }
}

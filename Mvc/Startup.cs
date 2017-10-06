using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Datas;
using Services;

namespace Mvc
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
            var connStr=Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VueDbContext>(p =>
                {                    
                    p.UseSqlite(connStr);
                });

            /*
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<VueDbContext>()
            .AddDefaultTokenProviders();
            */

            //添加支持Mvc
            services.AddMvc();
            //添加IConfigurationRoot的单例的依赖注入
            services.AddSingleton(provider => Configuration);
            //添加Repository的依赖注入
            services.AddTransient<Repository>();
            //添加GreetingService的依赖注入
            services.AddScoped<GreetingService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using Infrastructure.Data;
using EShop.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using WEB.Interfaces;
using WEB.Areas.Admin.Services;
using WEB.Models;

namespace EShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EShopContext>(c =>
            {
                try
                {
                    // Requires LocalDB which can be installed with SQL Server Express 2016
                    // https://www.microsoft.com/en-us/download/details.aspx?id=54284
                    c.UseSqlServer(Configuration.GetConnectionString("EShopConnection"));
                }
                catch (System.Exception ex)
                {
                    var message = ex.Message;
                }
            });

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductAttributeValueRepository, ProductAttributeValueRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddTransient<>(IProductRepository, ProductRepository);
            services.AddMvc();

            services.AddDbContext<WEBContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("WEBContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();


            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            //app.UseSession();

            app.UseMvc(routes =>
                {
                    //Added area admin
                    routes.MapRoute(
                        name: "areas",
                        template: "{area:exists}/{controller=Home}/{action=Index}");

                    //default route
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
           
        }
    }
}

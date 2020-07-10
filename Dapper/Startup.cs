using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using WX.Applications;
using WX.Applications.Itemplate;
using Dapper.Webapi.controllerBase;
using Microsoft.EntityFrameworkCore.Sqlite;
using Orm.MVC.Model;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Dapper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        ILogger<NlogController> logger;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddRazorPages();

            services.AddControllersWithViews();  // 添加 mvc 需要的 各种服务

            //services.AddDbContext<Orm.MVC.Model.DataContenx>(optionsBuilder =>
            //{

            //    var config = Configuration.GetSection("ConnectionSetting").Get<Consqlcontion>();
            //    optionsBuilder.UseSqlServer(config.ReadConnectionString);
            //});


            services.AddSession();

            services.AddSwaggerGen((c) =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Version = "v1.1.0",
                    Title = "WebApi",
                    Description = "WebApi框架",
                    TermsOfService = null
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Dapper.Webapi.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();

            services.AddDbContext<DbContext>(c =>
            {
                c.UseSqlServer("Data Source=.;Initial Catalog=ZhiHu;Integrated Security=True");
            });

            services.AddMvc(c=>c.EnableEndpointRouting=false).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else 
            //{
            //    app.UseExceptionHandler("/Error");
            //    app.UseStaticFiles();
            //}

            app.UseSession();

            //你是逗比
            app.UseSwagger();
            app.UseSwaggerUI((c) =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "dsadasdasdas");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});



            app.UseStaticFiles();

            app.UseAuthorization();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

            });

            //app.UseEndpoints = false;

            //contenx.Database.EnsureCreated();
        }
    }
}

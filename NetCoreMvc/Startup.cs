using System;
using System.Collections.Generic;
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
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Orm.MVC.SqlClient;

namespace NetCoreMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Console.WriteLine("E");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            Console.WriteLine("F");

            var count = 3700 + 2849 + 5169 + 999;

            services.AddControllersWithViews();
            services.AddControllers();
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
                var xmlPath = Path.Combine(basePath, "NetCoreMvc.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<NoteContext>(option =>
            {
                option.UseSqlServer("server=.;database=Note;uid=sa;pwd=123456");
            });

            services.AddMvc(c => c.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            Console.WriteLine("G");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();  // 使用session

            app.UseSwagger();
            app.UseSwaggerUI((c) =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "dsadasdasdas");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();  //使用授权

            app.UseMvc(c =>
            {
                c.MapRoute(name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}

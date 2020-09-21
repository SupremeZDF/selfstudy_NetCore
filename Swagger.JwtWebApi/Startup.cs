using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
     
namespace Swagger.JwtWebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //Ìí¼ÓÎÄµµÐÅÏ¢
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "webapi",
                    Version = "v1.1",
                    Description = "ASP.NET CORE WebApi",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Jee",
                        Email="princess@GMAIL.COM"
                    }
                });
                //string[] str = new string[] { "1" };
                //var ss = string.Join('c',new string[] {"s","s"});
                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; //Swagger.JwtWebApi.xml
                var a = AppDomain.CurrentDomain.BaseDirectory;  //D:\Ñ§Ï°\Á·Ï°Excitens\WX\excitensOne\wx.webapi\Swagger.JwtWebApi\bin\Debug\netcoreapp3.1\netcoreapp3.1\
                var b = PlatformServices.Default.Application.ApplicationBasePath;    //D:\Ñ§Ï°\Á·Ï°Excitens\WX\excitensOne\wx.webapi\Swagger.JwtWebApi\bin\Debug\netcoreapp3.1\
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);  //D:\Ñ§Ï°\Á·Ï°Excitens\WX\excitensOne\wx.webapi\Swagger.JwtWebApi\bin\Debug\netcoreapp3.1\Swagger.JwtWebApi.xml
                //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_0);
                c.IncludeXmlComments(xmlpath,true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Corewebapi");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

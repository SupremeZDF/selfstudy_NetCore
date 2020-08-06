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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore;
using System.IO;
using NetcoreMvc.Model.Model;
using NetcoreMvc.Model.Registoory;
using Microsoft.AspNetCore.Identity;
using AutoMapper.Mappers;
using AutoMapper;
using NetcoreMvc.Model.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace NetcoreMvc.WebApi
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
            //string Name = string.Join(",", new List<string> { "234","34234","34234"});


            services.AddControllers();

            //var constr = Configuration.GetConnectionString("sqlver");

            services.AddControllersWithViews();
            services.AddRazorPages();

            //services.AddDbContext<AppDBContent>(options => options.UseSqlServer(constr));

            //services.AddIdentity()

            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", policy =>
                {
                    // 设定允许跨域的来源，有多个可以用','隔开
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            //services.AddTransient<IGetUser, GetUser>();

            //services.AddAutoMapper(typeof(AutoMapperConfig));


            // bearar  持票人 获取方案名称 未请求特定方案时会默认使用此名称
            // var authencation = JwtBearerDefaults.AuthenticationScheme;
            // services.AddAuthentication(authencation).AddJwtBearer(authencation, options => Configuration.Bind("JwtSettings", options))
            //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => Configuration.Bind("CookieSettings", options)); //身份验证  鉴定 



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
                var xmlPath = Path.Combine(basePath, "NetcoreMvc.WebApi.xml");
                c.IncludeXmlComments(xmlPath);
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

            app.UseSwaggerUI((c) =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "dsadasdasdas");
            });

            app.UseRouting();

            //授权
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

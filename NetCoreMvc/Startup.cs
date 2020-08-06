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
using Orm.MVC;
using Orm.MVC.IOC;
using Orm.MVC.Implate;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Autofac.Extras.DynamicProxy;
using Autofac.Extensions.DependencyInjection;
using Autofac;

namespace NetCoreMvc
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
            services.AddControllersWithViews();
            services.AddControllers().AddControllersAsServices();
            services.AddSession();


            //services.BuildServiceProvider


            ////傻狗
            //services.AddTransient<Ittansient, Transient>(); //
            //services.AddScoped<Iscope, Scope>();
            services.AddTransient<ISingleton, Singleton>();
            services.AddTransient<Singleton>();
            //services.AddTransient<Ittansient>(c =>

            ////services.TryAddEnumerable(); //如果存在相同 不注册进去 不相同 则可以注册进去
            //{
            //    return new Transient();
            //});


            //services.AddSingleton(typeof(Itypeservice<>), typeof(TpeyServcie<>));

            //IServiceProviderFactory

            //services.AddSingleton();

            //services.RemoveAll<>();

            //services.Replace(ServiceDescriptor.Transient<Ittansient,Transient>()); 替换服务


            //services.AddTransient<IdisposableService, DisposAbleService>();
            //services.AddSingleton<IdisposableService, DisposAbleService>();

            // services.AddScoped<IdisposableService, DisposAbleService>();

            //services.AddSingleton<IdisposableService>(p => new DisposAbleService());

            var servicesData = new DisposAbleService();
            //IServiceProviderFactory
            services.AddSingleton<IdisposableService>(servicesData);



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

            //var i = services.BuildServiceProvider();

            //i.GetService<ISingleton>();

            services.AddDbContext<NoteContext>(option =>
            {
                option.UseSqlServer("server=.;database=Note;uid=sa;pwd=123456");
            });

            services.AddMvc(c => c.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder) 
        {
            //
            //builder.RegisterType<MyserviceA>().As<IMyservice>();
            //builder.RegisterType<MyserviceB>().Named<IMyservice>("Named").PropertiesAutowired();

            //builder.RegisterType<MyNameService>();

            builder.RegisterType<MyInterceptor>();
            //builder.RegisterType<MyserviceB>().As<IMyservice>().PropertiesAutowired().InterceptedBy(typeof(MyInterceptor)).EnableInterfaceInterceptors();

            builder.RegisterType<MyserviceA>().PropertiesAutowired().InterceptedBy(typeof(MyInterceptor)).EnableClassInterceptors();
        }


        public ILifetimeScope lifetimeScope { get; private set; }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            lifetimeScope = app.ApplicationServices.GetAutofacRoot();

            //var autoService = this.lifetimeScope.Resolve<IMyservice>();

            var autserviceName = lifetimeScope.Resolve<MyserviceA>();

            //autoService.showCode();

            autserviceName.showCode();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //var data = app.ApplicationServices.GetService<ISingleton>();

            app.UseSession();  // 使用session

            //var code = data.GetHashCode();

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

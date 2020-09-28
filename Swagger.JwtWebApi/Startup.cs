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
            TestArraySeg();
            //int ccc;
            //cc(ref ccc);
            int ww;
            cc(out ww);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //添加文档信息
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "webapi",
                    Version = "v1.1",
                    Description = "ASP.NET CORE WebApi",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Jee",
                        Email = "princess@GMAIL.COM"
                    }
                });
                //string[] str = new string[] { "1" };
                //var ss = string.Join('c',new string[] {"s","s"});
                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; //Swagger.JwtWebApi.xml
                var a = AppDomain.CurrentDomain.BaseDirectory;  //D:\学习\练习Excitens\WX\excitensOne\wx.webapi\Swagger.JwtWebApi\bin\Debug\netcoreapp3.1\netcoreapp3.1\
                var b = PlatformServices.Default.Application.ApplicationBasePath;    //D:\学习\练习Excitens\WX\excitensOne\wx.webapi\Swagger.JwtWebApi\bin\Debug\netcoreapp3.1\
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);  //D:\学习\练习Excitens\WX\excitensOne\wx.webapi\Swagger.JwtWebApi\bin\Debug\netcoreapp3.1\Swagger.JwtWebApi.xml
                //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_0);
                c.IncludeXmlComments(xmlpath, true);
            });
        }

        private void TestArraySeg()
        {
            int[] a1 = new int[] { 1, 3, 5, 7, 9 };
            int[] a2 = new int[] { 2, 4, 6, 8, 10 };

            var seg = new ArraySegment<int>[2]
            {
            new ArraySegment<int>(a1, 0, 3),
            new ArraySegment<int>(a2, 2, 3)
            };

            ArraySegment<int>[] ss = new ArraySegment<int>[2]{ new ArraySegment<int>(),new ArraySegment<int>()};
            //List<ArraySegment()>

            var a ="SumArraySegment = " + SumArraySegment(seg) ;

            for (int i = 0; i < a1.Length; i++)
            {
                var b = "a1 = " + a1[i];
            }

            for (int i = 0; i < a2.Length; i++)
            {
                var c = "a2 = " + a2[i];
            }
            //List<List<string>> vs1 = new List<List<string>>();
            //foreach(var i in )
        }

        private int SumArraySegment(ArraySegment<int>[] seg)
        {
            var c= seg[0].Array;
            int sum = 0;
            for (int i = 0; i < seg.Length; i++)
            {
                for (int j = seg[i].Offset; j < seg[i].Offset + seg[i].Count; j++)
                {
                    //可以通过数组段访问原数组，修改原数组的值
                    seg[i].Array[j] = 0;
                    //sum += seg[i].Array[j];
                }
            }
            return sum;

        }
        public void cc(out int i)
        {
            i = 5;
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

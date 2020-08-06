using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetcoreMvc.Model.AutoMapper;
using NetcoreMvc.Model.DBCotenxTool;

namespace NetcoreMvc.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //using (var serviceProvider = host.Services.CreateScope()) 
            //{
            //    var service = serviceProvider.ServiceProvider;
            //    try
            //    {
            //        DBInitTool.Sennd(service);
            //        new StudentService(service.GetRequiredService<IMapper>()).GetStudentInfo();
            //    }
            //    catch (Exception ex)
            //    {
            //        //获取服务
            //        var loggerService = serviceProvider.ServiceProvider.GetRequiredService<ILogger<Program>>();
            //        loggerService.LogError(ex,"sdasdasdasd");
            //    }
            //}
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

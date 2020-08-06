using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orm.MVC.Delegate;
using Orm.MVC;
using Orm.MVC.IOC;
using Orm.MVC.Implate;
using Orm.MVC.Model;
using Autofac.Core;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NetCoreMvc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Test : ControllerBase
    {
        //public readonly Itypeservice<ISingleton> _itypeservice;

        //public Test(ISingleton singleton , Itypeservice<ISingleton> itypeservice) 
        //{
        //    _itypeservice = itypeservice;
        //    //_itypeservice.
        //}

        /// <summary>
        /// 
        /// </summary>
        //public Test(IdisposableService disposAbleService, IdisposableService idisposableService2)
        //{
        //    var datas = HttpContext.RequestServices;
        //    using (var service = HttpContext.RequestServices.CreateScope())
        //    {
        //        //var data = HttpContext.RequestServices;
        //        //var ser = data.GetService<ISingleton>();

        //        var data = service.ServiceProvider.GetService<IdisposableService>();

        //        Console.WriteLine(data.GetHashCode());
        //    }
        //}
        public readonly IdisposableService _idisposableService;

        [HttpGet]
        public void Run() 
        {
            new OneDelegate().Expressions();
        }

        [HttpGet]
        public void Two() 
        {
            new TwoDelegate();
        }

        [HttpGet]
        public void FormService([FromServices]IdisposableService disposAbleService,[FromServices]IdisposableService idisposableService2,
            [FromServices]IHostApplicationLifetime hostApplicationLifetime, [FromQuery]bool bl) 
        {

            using (var service = HttpContext.RequestServices.CreateScope())
            {
                //var data = HttpContext.RequestServices;
                //var ser = data.GetService<ISingleton>();

                //IHostApplicationLifetime 管理应用程序

                var data = service.ServiceProvider.GetService<IdisposableService>();

                var data1 = service.ServiceProvider.GetService<IdisposableService>();

                var data2 = service.ServiceProvider.GetService<IdisposableService>();

                hostApplicationLifetime.StopApplication();
            }
        }


        [HttpGet]
        public void Three() 
        {
            ThreeDeldegate.Assembl();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ittansient"></param>
        /// <param name="ittansient2"></param>
        /// <param name="iscope"></param>
        /// <param name="iscope2"></param>
        /// <param name="singleton"></param>
        /// <param name="singleton2"></param>
        //public  Test([FromServices]Ittansient ittansient,[FromServices]Ittansient ittansient2,
        //    [FromServices]Iscope iscope,[FromServices]Iscope iscope2,[FromServices]ISingleton singleton,ISingleton singleton2) 
        //{

        //    Console.WriteLine(ittansient.GetHashCode());  // A hash code for the current object. 当前对象的散列代码
        //    Console.WriteLine(ittansient2.GetHashCode());

        //    Console.WriteLine(iscope.GetHashCode());
        //    Console.WriteLine(iscope2.GetHashCode());

        //    Console.WriteLine(singleton.GetHashCode());
        //    Console.WriteLine(singleton2.GetHashCode());
        //    Console.WriteLine();
        //}


        //[HttpGet]
        //public void Four() 
        //{
        //    new FourcDelegate().One();
        //}


       
        [HttpGet]
        public void Five() 
        {
            new FiveDelegate().Run();
        }
    }
}

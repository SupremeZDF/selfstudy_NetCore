using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Dapper.Webapi.Controllers
{
    public class TestController : Controller
    {

        public readonly IMemoryCache _cache;

        public TestController(IMemoryCache cache) 
        {
            _cache = cache;
        }

        public IActionResult Index()
        {

            //ViewData["A"] = 100;
            //ViewData["B"] = "123";
            //ViewBag.Inte = "123";
            //ViewBag.s = 123;
            //a.name = "123";
            //a.pawd = "123";

            //var c = a.name;

            ViewData["Key"] = 1;
            TempData["userName"] = "123";

            ISession session = HttpContext.Session;
            session.SetInt32("A", 1);
            session.SetString("B", "sadasdas");

            _cache.Set("A","123");
            _cache.Set("B","SDASD");

            //session["1323"] = 12;

            return View();
        }

        public ActionResult Read() 
        {

            


            ISession session = HttpContext.Session;
            var A = session.GetInt32("A");

            var B = session.GetString("B");
            return View();
        }
    }


    public interface A 
    {
        
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Webapi.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {

            //ViewData["A"] = 100;
            //ViewData["B"] = "123";
            //ViewBag.Inte = "123";
            //ViewBag.s = 123;
            //a.name = "123";
            //a.pawd = "123";

            //var c = a.name;

            return View();
        }
    }
}
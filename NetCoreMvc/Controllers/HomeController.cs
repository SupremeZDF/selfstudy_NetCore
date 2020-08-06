using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WX.Model.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Orm.MVC.Model;

namespace NetCoreMvc.Controllers
{
    public class HomeController : Controller
    {


        public readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) 
        {
            _logger = logger;
        }

        public IActionResult Index()
       {

            _logger.LogInformation("123231");

            //ViewBag["data"] = "12313";
            ViewBag.data = new CreateUsercs()
            {
                Id = 1,
                Name = "23",
                Pswd = "3423"
            };
            ViewData["sadas"] = "123";
            TempData["sdasd"] = "231";

            //HttpContext.Session.GetString();

            base.HttpContext.Session.SetString("creteMVC",Newtonsoft.Json.JsonConvert.SerializeObject(new CreateUsercs()
            {
                Id = 1,
                Name = "23",
                Pswd = "3423"
            }));

            return View();
        }
    }
}
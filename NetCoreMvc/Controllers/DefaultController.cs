using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCoreMvc.Controllers
{
    public class DefaultController : Controller
    {

        //public readonly ILogger<def>

        public IActionResult Index()
        {
            return View();
        }
    }
}
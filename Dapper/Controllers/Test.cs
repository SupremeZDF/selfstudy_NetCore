using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Webapi.Controllers
{
    //[Controller]
    public class Test : BTActionBaseController
    {
        [HttpGet]
        public string A()
        {
            return "123";
        }
    }
}

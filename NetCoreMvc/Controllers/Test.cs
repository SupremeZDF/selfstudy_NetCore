using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orm.MVC.Delegate;

namespace NetCoreMvc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Test : ControllerBase
    {
        [HttpGet]
        public void Run() 
        {
            new OneDelegate().Expressions();
        }

        [HttpGet]
        public void Two() 
        {
            new TwoDelegate().Three();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Swagger.JwtWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Exercise : ControllerBase
    {
        //设置过期时间位20秒
        [ResponseCache(Duration = 20)]
        public void Name() 
        {
          
        }
    }
}

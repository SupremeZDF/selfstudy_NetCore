using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetcoreMvc.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost]
        public void OneFileUpload(IFormCollection formFiles) 
        {
           //HttpContext.Request.
        }

        [HttpPost]
        public void One() 
        {
            var t = "2020-12-12";
            var data = Convert.ToDateTime(t);
        }

        [HttpGet]
        public void Name() 
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetcoreMvc.Model.TASK;
using NetcoreMvc.Model.Quarlz;
using System.Text;
using System.Security.Cryptography.Xml;

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
            QuarlzManager.SchedulerFactory();
        }

        [HttpGet]
        public void TwoNaame() 
        {
            //int temp = 0;
            //byte[] bytes = Encoding.UTF8.GetBytes(temp.ToString());
            //temp = BitConverter.ToInt32(bytes);

            //string a = "", b = "", c = "";

            //for (int d = 0, e = 0; d < 12; d++)
            //{

            //}

           

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public void ComPareObject() 
        {
            var a = new List<string>() { "123","123"};
            var b = new List<string>() { "123", "123" };

            if (a == b) 
            {
                var c = 1;
            }

            //if (a === b) 
            //{
            //    var d = 1;
            //}
        }

        [HttpGet]
        public void Names() 
        {
            //var c=Math.Ceiling
            //foreach(var i in )
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public void StoredProcedure() 
        {
            new Model.OnExercise().StoredProcedure();
        }
    }
}

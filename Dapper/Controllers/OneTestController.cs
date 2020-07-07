using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WX.Applications.Dappers;
using Orm.MVC.Model;

namespace Dapper.Controllers
{
    public class OneTestController : BTActionBaseController
    {
        //public readonly DataContenx _contenx;

        //public OneTestController(DataContenx contenx) 
        //{
        //    _contenx = contenx;
        //}

        [HttpPost]
        public void Run() 
        {

             
            //OneSqlqer.SelectUser();
            OneSqlqer.InSelect();
            //OneSqlqer.InsertList();
            //OneSqlqer.DataClass();
        }

        [HttpGet]
        public void GetRun()
        {
            //var data = _contenx.t_Questions.ToList();
            //var data = HttpContext.Session.Set();
        }
    }
}
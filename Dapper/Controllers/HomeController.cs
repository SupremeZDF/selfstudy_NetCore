using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Orm.MVC.Model;
using Orm.MVC.Page;
using System.Dynamic;
using Microsoft.Extensions.Caching.Memory;

using System.Reflection;

namespace Dapper.Webapi.Controllers
{
    public class HomeController : Controller
    {
        public readonly DataContenx _contenx;

        //public List<T_Question> t_Questions { get; set; }

        public readonly IMemoryCache _cache;

        public HomeController(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            View();
            return View();
        }

        [HttpPost]
        public void Head([FromHeader]string ss) 
        {
            var a = ss;
        }

        public IActionResult Returnresult() 
        {
            return new JsonResult("sdssa");
            //return Json();
        }

        public IActionResult Name() 
        
        {
            //dynamic name = new ExpandoObject();
            //name.Image = "123";
            //var c = name.Image;


            //ViewData["A"] = "123";
            //ViewBag.A = "456";

            //ViewBag.C = 2;

            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            //keyValuePairs.Add("123", "123");
            //var datas= keyValuePairs["123"];

            //var data = new List<string>();
            //data.Add("1");
            //data.Add("1");
            //data.Add("1");
            //data.Add("1");
            //data.Add("1");
            //data.Add("1");
            //data.Add("1");
            //data.Add("1");
            //data.Add("1");

            //ViewBag.data = data;
            //ViewData["list"] = data;

            //ViewBag.Test = "123";

            T_Question t_Question = new T_Question()
            {
                Content = "123",
                DataTime = DateTime.Now,
                Headline = "123"
            };
            return View(t_Question);
            //return Redirect("/home/index");
        }

        public IActionResult ReturnView() 
        {
            return Redirect("");
        }

        public async Task<IActionResult> T_QuestionIndex() 
        {

            //t_Questions = _contenx.t_Questions.ToList();
            //if (!ModelState.IsValid) 
            //{
            //    return View();
            //}

            //_contenx.t_Questions.Add(
            //    new T_Question() 
            //    { 
            //        DataTime = DateTime.Now ,
            //        Content="123",
            //        Image="/sdasd",
            //        UserID=27,
            //        IssusClassifYid=2, 
            //        Headline="123", 
            //        IssuestateID=1 
            //    }) ;

            //await _contenx.SaveChangesAsync();
            return View();
        }


        public IActionResult T_Son() 
        {
            return View();
        }


        public IActionResult Partial() 
        {
            return PartialView("~/Views/Home/t_sons.cshtml");
            //return PartialView("~/Views/Home/t_sons.cshtml");
        }



        public IActionResult memoryCache()
        {

            var A = _cache.Get("A");

            var B = _cache.Get("B");

            return View();
        }

        [HttpPost]
        public void requird(User user) 
        {


        }


        public void EF() 
        {
            //using (var db = new DataContenx())
            //{
            //    var data = db.T_Question.ToList();
            //}
        }

    }
}
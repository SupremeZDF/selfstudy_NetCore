﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swagger.JwtWebApi.model;

namespace Swagger.JwtWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Exercise : ControllerBase
    {
        /// <summary>
        /// abcdefghijklmn
        /// </summary>
        [HttpGet]
        public OneModel Name([FromQuery]int aa) 
        {
            return new OneModel() { };
        }
    }
}

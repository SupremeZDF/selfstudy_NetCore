﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BTActionBaseController : ControllerBase
    {
        public BTActionBaseController() 
        {
        
        }
    }
}
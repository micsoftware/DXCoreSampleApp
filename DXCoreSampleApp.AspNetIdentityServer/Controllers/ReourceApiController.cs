﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DXCoreSampleApp.AspNetIdentityServer.Controllers
{
    [Produces("application/json")]
    [Route("api/ReourceApi")]
    public class ReourceApiController : Controller
    {
        [Authorize]
        public IActionResult Get()
        {
            
            return Ok();
        }
    }
}
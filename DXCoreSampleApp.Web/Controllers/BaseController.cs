using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DXCoreSampleApp.Identity;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DXCoreSampleApp.Web.Controllers
{
    
    public class BaseController : Controller
    {
       

        public BaseController()
        {
            
        }
        public int TenantId { get => 1; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DXCoreSampleApp.AspNetIdentityServer.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DXCoreSampleApp.AspNetIdentityServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
           
            
            foreach(var claim in User.Claims)
            {
                ViewData["Message"] = claim.ToString();
            }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

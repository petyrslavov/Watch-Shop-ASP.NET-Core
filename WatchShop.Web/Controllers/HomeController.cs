using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Web.Models;

namespace WatchShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.User.IsInRole("Admin"))
            {
                return this.RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Web.Data;
using WatchShop.Web.Models;
using WatchShop.Web.Models.ViewModels;

namespace WatchShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(WatchShopDbContext context)
        {
            this.context = context;
        }

        public WatchShopDbContext context { get; set; }

        public IActionResult Index()
        {
            if (this.User.IsInRole("Admin"))
            {
                return this.RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            var username = User.Identity.Name;

            var user = this.context.Users
                .Include(c => c.Cart)
                .FirstOrDefault(u => u.UserName == username);

            if (user != null && user.Cart != null)
            {
                var cart = this.context.Carts.FirstOrDefault(p => p.Id == user.Cart.Id);

                var model = new[] { cart }
                .Select(CartViewModel.FromCart).FirstOrDefault();

                return View(model);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return this.View();
        }
    }
}

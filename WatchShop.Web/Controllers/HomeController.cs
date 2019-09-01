using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Web.Data;
using WatchShop.Web.Models;
using WatchShop.Web.Models.ViewModels;

namespace WatchShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        public WatchShopDbContext context { get; set; }

        public HomeController(WatchShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


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

                var model = mapper.Map<CartViewModel>(cart);

                return View(model);
            }
            
            return View();
        }

        
    }
}

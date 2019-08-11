using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Models;
using WatchShop.Web.Data;
using WatchShop.Web.Models.BindingModels;

namespace WatchShop.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public OrderController(WatchShopDbContext context)
        {
            this.context = context;
        }

        public WatchShopDbContext context { get; set; }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(OrderBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var username = User.Identity.Name;

            var user = this.context.Users
                 .Include(c => c.Cart)
                 .ThenInclude(p => p.Products)
                 .ThenInclude(p => p.Product)
                 .FirstOrDefault(u => u.UserName == username);


            var order = new PendingOrder()
            {
                Address = model.Address,
                FullName = model.FullName,
                IsConfirmed = false,
                Items = new List<CartItem>(user.Cart.Products)
            };

            this.context.PendingOrders.Add(order);
            user.Cart.Products.Clear();
            this.context.SaveChanges();

            
            return RedirectToAction("Index", "Home");
        }
    }
}
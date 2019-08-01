using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Models;
using WatchShop.Web.Data;
using WatchShop.Web.Models.BindingModels;

namespace WatchShop.Web.Controllers
{
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
            var user = User.Identity.Name;

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(OrderBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }
            var order = this.context.PendingOrders.First();

            order.Address = model.Address;
            order.FullName = model.FullName;
            order.IsConfirmed = true;

            this.context.SaveChanges();

            return View();
        }
    }
}
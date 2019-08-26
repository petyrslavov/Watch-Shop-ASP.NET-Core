using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Models;
using WatchShop.Services;
using WatchShop.Services.ServicesModels;
using WatchShop.Web.Data;
using WatchShop.Web.Models.BindingModels;

namespace WatchShop.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(WatchShopDbContext context, IOrderService orderService)
        {
            this.context = context;
            this.orderService = orderService;
        }

        public WatchShopDbContext context { get; set; }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(OrderServiceBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var username = User.Identity.Name;

            orderService.CreateOrder(model, username);
            
            return RedirectToAction("Index", "Home");
        }
    }
}
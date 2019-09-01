using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Services;
using WatchShop.Services.ServicesModels;
using WatchShop.Web.Areas.Admin.Models.ViewModels;
using WatchShop.Web.Data;

namespace WatchShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PendingOrderController : Controller
    {
        private readonly WatchShopDbContext context;
        private readonly IOrderService orderService;

        public PendingOrderController(WatchShopDbContext context, IOrderService orderService)
        {
            this.context = context;
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var orders = orderService.GetAllPendingOrders();

            return View(orders);
        }

        [HttpGet]
        public IActionResult OrderDetails(string id)
        {
            var order = orderService.GetOrderDetails(id);

            return View(order);
        }

        [HttpPost]
        public IActionResult Confirm(string id)
        {
            orderService.ConfirmOrder(id);

            return RedirectToAction("All", "PendingOrder");
        }
    }
}
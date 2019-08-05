using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Web.Areas.Admin.Models.ViewModels;
using WatchShop.Web.Data;

namespace WatchShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PendingOrderController : Controller
    {
        private readonly WatchShopDbContext context;

        public PendingOrderController(WatchShopDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            var orders = this.context.PendingOrders
                .Include(i => i.Items)
                .Where(c => c.IsConfirmed == false)
                .ToList();

            var model = orders
            .Select(OrdersViewModel.FromOrder)
            .ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Confirm(string id)
        {
            var confirmOrder = this.context.PendingOrders
               .FirstOrDefault(o => o.Id == id);

            confirmOrder.IsConfirmed = true;

            this.context.PendingOrders.Update(confirmOrder);
            this.context.SaveChanges();

            return RedirectToAction("All", "PendingOrder");
        }
    }
}
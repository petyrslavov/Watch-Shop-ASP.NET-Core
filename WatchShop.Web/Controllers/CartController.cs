using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Models;
using WatchShop.Web.Data;
using WatchShop.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace WatchShop.Web.Controllers
{
    public class CartController : Controller
    {
      
        public CartController(WatchShopDbContext context)
        {
            this.context = context;
        }


        public WatchShopDbContext context { get; set; }

        [HttpGet]
        public IActionResult Bag(string id)
        {
            var cart = this.context.Carts
                .Include(p => p.Products)
                .ThenInclude(p => p.Product)
                .SingleOrDefault(p => p.Id == id);

            var model = cart.Products
                .Select(p => p.Product)
                .Select(ProductViewModel.FromProduct)
                .ToList();

            return View(model);
        }


        [HttpPost]
        public IActionResult Remove(string id)
        {
            var productToRemove = this.context.CartItems
                .Include(p => p.Product)
                .FirstOrDefault(p => p.ProductId == id);

            this.context.CartItems.Remove(productToRemove);
            this.context.SaveChanges();

            return RedirectToAction("Bag", "Cart");
        }
    }
}
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
using AutoMapper;

namespace WatchShop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IMapper mapper;
        public WatchShopDbContext context { get; set; }

        public CartController(WatchShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Bag(string id)
        {
            var cart = this.context.Carts
               .Include(p => p.Products)
               .ThenInclude(p => p.Product)
               .SingleOrDefault(p => p.Id == id);

            var products = cart.Products
                .Select(p => p.Product)
                .ToList();

            var model = mapper.Map<IEnumerable<ProductViewModel>>(products);

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

            var username = this.User.Identity.Name;
            var user = this.context.Users.Include(c => c.Cart).FirstOrDefault(u => u.UserName == username);
            var cartId = user.Cart.Id;

            return RedirectToAction("Bag", "Cart", new {  id = cartId });
        }
    }
}
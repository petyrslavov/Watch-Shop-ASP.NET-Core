using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Web.Data;
using WatchShop.Web.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using WatchShop.Services;

namespace WatchShop.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public WatchShopDbContext context { get; set; }

        public CartController(WatchShopDbContext context, ICartService cartService)
        {
            this.context = context;
            this.cartService = cartService;
        }

        [HttpGet]
        public IActionResult Bag(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userCart = cartService.GetUserCart(id);

            return View(userCart);
        }

        [HttpPost]
        public IActionResult Remove(string id)
        {
            cartService.RemoveProductFromCart(id);

            var username = this.User.Identity.Name; 
            var user = this.context.Users.Include(c => c.Cart).FirstOrDefault(u => u.UserName == username);
            var cartId = user.Cart.Id;

            return RedirectToAction("Bag", "Cart", new {  id = cartId });
        }
    }
}
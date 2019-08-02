using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Models;
using WatchShop.Web.Data;
using WatchShop.Web.Models.ViewModels;

namespace WatchShop.Web.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(WatchShopDbContext context)
        {
            this.context = context;
        }

        public WatchShopDbContext context { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [HttpGet]
        public IActionResult All()
        {
            var products = this.context.Products.ToList();

            var model = products
            .Select(ProductViewModel.FromProduct)
            .ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var product = this.context.Products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return this.NotFound();
            }

            var model = new[] { product }
            .Select(ProductDetailsViewModel.FromProduct)
            .First();

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Category(string id)
        {
            var products = this.context.Products.Where(c => c.Category.Name == id).ToList();

            var model = products
            .Select(ProductViewModel.FromProduct)
            .ToList();

            return View(model);
        }


        [HttpGet]
        public IActionResult Search()
        {
            if (string.IsNullOrEmpty(this.SearchTerm))
            {
                return RedirectToAction("Index", "Home");
            }

            var foundProducts = this.context.Products
                .Where(a => a.Model.ToLower().Contains(this.SearchTerm.ToLower()))
                .OrderBy(a => a.Model)
                .Select(ProductViewModel.FromProduct)
                .ToList();

            return this.View(foundProducts);
        }

        [HttpPost]
        public IActionResult Add(string id)
        {
            var username = User.Identity.Name;

            var user = this.context.Users
                .Include(c => c.Cart)
                .ThenInclude(p => p.Products)
                .ThenInclude(p => p.Product)
                .FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            var product = this.context.Products.Find(id);

            if (product == null)
            {
                return this.View();
            }

            if (user.Cart == null)
            {
                user.Cart = new Cart();
            }

            var cartItem = new CartItem()
            {
                Product = product,
                ProductId = product.Id,
            };

            user.Cart.Products.Add(cartItem);
            this.context.SaveChanges();

            return RedirectToAction("Bag", "Cart", new { user.Cart.Id });
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Models;
using WatchShop.Services;
using WatchShop.Web.Data;
using WatchShop.Web.Models.ViewModels;

namespace WatchShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public WatchShopDbContext context { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ProductController(WatchShopDbContext context, IProductService productService)
        {
            this.context = context;
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var products = productService.GetAllProducts();

            return View(products);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var product = productService.GetProductDetails(id);

            if (product == null)
            {
                return this.NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Category(string id)
        {
            var products = productService.GetProductsByCategory(id);

            return View(products);
        }

        [HttpGet]
        public IActionResult Search()
        {
            if (string.IsNullOrEmpty(this.SearchTerm))
            {
                return null;
            }

            var searchTerm = this.SearchTerm;
            var products = productService.SearchProduct(searchTerm);

            return this.View(products);
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
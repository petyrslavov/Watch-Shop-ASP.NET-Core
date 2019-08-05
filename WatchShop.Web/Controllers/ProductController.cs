using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchShop.Models;
using WatchShop.Web.Data;
using WatchShop.Web.Models.ViewModels;

namespace WatchShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper mapper;
        public WatchShopDbContext context { get; set; }

        public ProductController(WatchShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [HttpGet]
        public IActionResult All()
        {
            var products = this.context.Products.ToList();

            var model = mapper.Map<IEnumerable<ProductViewModel>>(products);

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

            var model = mapper.Map<ProductDetailsViewModel>(product);

            return View(model);
        }

        [HttpGet]
        public IActionResult Category(string id)
        {
            var products = this.context.Products.Where(c => c.Category.Name == id).ToList();

            var model = mapper.Map<IEnumerable<ProductViewModel>>(products);

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
                .ToList();

            var model = mapper.Map<IEnumerable<ProductViewModel>>(foundProducts);

            return this.View(model);
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
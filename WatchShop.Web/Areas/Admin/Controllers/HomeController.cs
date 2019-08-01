using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Models;
using WatchShop.Web.Areas.Admin.Models.BindingModels;
using WatchShop.Web.Data;

namespace WatchShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    { 
        public HomeController(WatchShopDbContext context)
        {
            this.context = context;
        }

        public WatchShopDbContext context { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(WatchBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var category = new Category()
            {
                Name = bindingModel.Category,
            };

            this.context.Categories.Add(category);
            this.context.SaveChanges();


            var watch = new Product()
            {
                Model = bindingModel.Model,
                Description = bindingModel.Description,
                Price = bindingModel.Price,
                Image = bindingModel.Image,
                CategoryId = category.Id,
                Category = category  
            };

            this.context.Products.Add(watch);
            this.context.SaveChanges();

            return this.RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
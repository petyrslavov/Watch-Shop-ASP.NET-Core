using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Models;
using WatchShop.Web.Areas.Admin.Models.BindingModels;
using WatchShop.Web.Data;
using WatchShop.Services.ServicesModels;
using AutoMapper;
using WatchShop.Services;

namespace WatchShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IMapper mapper;

        public WatchShopDbContext context { get; set; }

        public HomeController(WatchShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

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
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchShop.Services.ServicesModels;
using WatchShop.Web.Data;

namespace WatchShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        public WatchShopDbContext context { get; set; }


        public ProductService(WatchShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<ProductServiceViewModel> GetAllProducts()
        {
            var products = this.context.Products.ToList();

            var model = mapper.Map<IEnumerable<ProductServiceViewModel>>(products);

            return model;
        }

        public ProductServiceDetailsViewModel GetProductDetails(string id)
        {
            var product = this.context.Products
               .FirstOrDefault(p => p.Id == id);

            var model = mapper.Map<ProductServiceDetailsViewModel>(product);

            return model;
        }

        public IEnumerable<ProductServiceViewModel> GetProductsByCategory(string category)
        {
            var products = this.context.Products.Where(c => c.Category.Name == category).ToList();

            var model = mapper.Map<IEnumerable<ProductServiceViewModel>>(products);

            return model;
        }

        public IEnumerable<ProductServiceViewModel> SearchProduct(string searchTerm)
        {
            var foundProducts = this.context.Products
                .Where(a => a.Model.ToLower().Contains(searchTerm.ToLower()))
                .OrderBy(a => a.Model)
                .ToList();

            var model = mapper.Map<IEnumerable<ProductServiceViewModel>>(foundProducts);

            return model;
        }
    }
}

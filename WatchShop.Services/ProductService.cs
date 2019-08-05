//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using WatchShop.Web.Data;
//using WatchShop.Web.Models.ViewModels;

//namespace WatchShop.Services
//{
//    public class ProductService : DbService, IProductService
//    {
//        public ProductService(WatchShopDbContext context)
//            : base(context) { }

//        public IEnumerable<ProductViewModel> GetAllProducts()
//        {
//            var products = this.context.Products.ToList();

//            var model = products
//            .Select(ProductViewModel.FromProduct)
//            .ToList();

//            return model;
//        }

//        public ProductDetailsViewModel GetProductDetails(string id)
//        {
//            var product = this.context.Products
//                .FirstOrDefault(p => p.Id == id);

//            var model = new[] { product }
//            .Select(ProductDetailsViewModel.FromProduct)
//            .First();

//            return model;
//        }
//    }
//}

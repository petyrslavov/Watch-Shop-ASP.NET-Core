using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.Models;

namespace WatchShop.Web.Models.ViewModels
{
    public class ProductViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public static Func<Product, ProductViewModel> FromProduct
        {
            get
            {
                return product => new ProductViewModel()
                {
                    Id = product.Id,
                    Model = product.Model,
                    Price = product.Price,
                    Image = product.Image,
                };
            }
        }
    }
}

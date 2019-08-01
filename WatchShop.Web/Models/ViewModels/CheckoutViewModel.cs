using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.Models;

namespace WatchShop.Web.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public string Id { get; set; }

        public string Item { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public static Func<Product, CheckoutViewModel> FromProduct
        {
            get
            {
                return product => new CheckoutViewModel()
                {
                    Id = product.Id,
                    Item = product.Image,
                    Price = product.Price,
                    Model = product.Model,
                };
            }
        }
    }
}

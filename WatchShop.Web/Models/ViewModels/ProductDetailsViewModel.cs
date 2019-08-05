using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.Models;

namespace WatchShop.Web.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

    }
}

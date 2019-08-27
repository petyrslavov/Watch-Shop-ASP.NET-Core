using System;
using System.Collections.Generic;
using System.Text;
using WatchShop.Models;

namespace WatchShop.Services.ServicesModels
{
    public class ProductServiceDetailsViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
    }
}

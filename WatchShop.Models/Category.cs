using System;
using System.Collections.Generic;
using System.Text;

namespace WatchShop.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

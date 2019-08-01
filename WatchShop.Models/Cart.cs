using System;
using System.Collections.Generic;
using System.Text;

namespace WatchShop.Models
{
    public class Cart
    {
        public Cart()
        {
            Products = new List<CartItem>();
        }
        public string Id { get; set; }

        public ICollection<CartItem> Products { get; set; }
    }
}

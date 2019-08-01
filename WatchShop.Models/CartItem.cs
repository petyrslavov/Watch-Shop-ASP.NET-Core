using System;
using System.Collections.Generic;
using System.Text;

namespace WatchShop.Models
{
    public class CartItem
    {
        public string Id { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public string PendingOrderId { get; set; }
    }
}

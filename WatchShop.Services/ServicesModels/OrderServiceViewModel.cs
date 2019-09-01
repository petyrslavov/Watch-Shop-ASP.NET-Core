using System;
using System.Collections.Generic;
using System.Text;
using WatchShop.Models;

namespace WatchShop.Services.ServicesModels
{
    public class OrderServiceViewModel
    {
        public OrderServiceViewModel()
        {
            this.Items = new List<CartItem>();
        }

        public string Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public bool isConfirmed { get; set; }

        public ICollection<CartItem> Items { get; set; }
    }
}

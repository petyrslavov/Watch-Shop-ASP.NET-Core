using System;
using System.Collections.Generic;
using WatchShop.Models;

namespace WatchShop.Web.Areas.Admin.Models.ViewModels
{
    public class OrdersViewModel
    {
        public OrdersViewModel()
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

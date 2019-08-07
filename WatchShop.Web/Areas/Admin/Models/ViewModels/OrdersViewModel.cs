﻿using System;
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

        public string Adress { get; set; }

        public bool isConfirmed { get; set; }

        public ICollection<CartItem> Items { get; set; }

        public static Func<WatchShop.Models.PendingOrder, OrdersViewModel> FromOrder
        {
            get
            {
                return order => new OrdersViewModel()
                {
                    Id = order.Id,
                    FullName = order.FullName,
                    Adress = order.Address,
                    isConfirmed = order.IsConfirmed,
                    Items = order.Items
                };
            }
        }
    }
}
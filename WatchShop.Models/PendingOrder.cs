using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WatchShop.Models
{
    public class PendingOrder
    {
        public PendingOrder()
        {
            Items = new List<CartItem>();
            IsConfirmed = false;
        }
        public string Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public bool IsConfirmed { get; set; }

        public ICollection<CartItem> Items { get; set; }

    }
}

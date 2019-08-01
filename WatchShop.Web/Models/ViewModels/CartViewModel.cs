using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.Models;

namespace WatchShop.Web.Models.ViewModels
{
    public class CartViewModel
    {
        public string Id { get; set; }

        public static Func<Cart, CartViewModel> FromCart
        {
            get
            {
                return cart => new CartViewModel()
                {
                    Id = cart.Id,
                };
            }
        }
    }
}

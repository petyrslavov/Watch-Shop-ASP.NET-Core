using System;
using System.Collections.Generic;
using System.Text;
using WatchShop.Services.ServicesModels;

namespace WatchShop.Services
{
    public interface ICartService
    {
        IEnumerable<ProductServiceViewModel> GetUserCart(string id);

        void RemoveProductFromCart(string id);
    }
}

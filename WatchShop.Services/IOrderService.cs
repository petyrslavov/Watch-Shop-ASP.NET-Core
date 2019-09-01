using System;
using System.Collections.Generic;
using System.Text;
using WatchShop.Services.ServicesModels;

namespace WatchShop.Services
{
    public interface IOrderService
    {
        void CreateOrder(OrderServiceBindingModel model, string username);

        IEnumerable<OrderServiceViewModel> GetAllPendingOrders();

        OrderServiceViewModel GetOrderDetails(string id);

        void ConfirmOrder(string id);
    }
}

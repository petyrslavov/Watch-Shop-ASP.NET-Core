using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchShop.Models;
using WatchShop.Services.ServicesModels;
using WatchShop.Web.Data;

namespace WatchShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;

        public WatchShopDbContext context { get; set; }

        public OrderService(WatchShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void CreateOrder(OrderServiceBindingModel model, string username)
        {
            var user = this.context.Users
                             .Include(c => c.Cart)
                             .ThenInclude(p => p.Products)
                             .ThenInclude(p => p.Product)
                             .FirstOrDefault(u => u.UserName == username);

            var order = mapper.Map<OrderServiceBindingModel, PendingOrder>(model);

            order.Items = new List<CartItem>(user.Cart.Products);

            this.context.PendingOrders.Add(order);
            user.Cart.Products.Clear();
            this.context.SaveChanges();
        }

        public IEnumerable<OrderServiceViewModel> GetAllPendingOrders()
        {
            var orders = this.context.PendingOrders
               .Include(i => i.Items)
               .Where(c => c.IsConfirmed == false)
               .ToList();

            var model = mapper.Map<IEnumerable<OrderServiceViewModel>>(orders);

            return model;
        }

        public OrderServiceViewModel GetOrderDetails(string id)
        {
            var order = this.context.PendingOrders
               .Include(i => i.Items)
               .Include("Items.Product")
               .FirstOrDefault(o => o.Id == id);

            var model = mapper.Map<OrderServiceViewModel>(order);

            return model;
        }

        public void ConfirmOrder(string id)
        {
            var confirmOrder = this.context.PendingOrders
               .FirstOrDefault(o => o.Id == id);

            confirmOrder.IsConfirmed = true;

            this.context.PendingOrders.Update(confirmOrder);
            this.context.SaveChanges();
        }
    }
}

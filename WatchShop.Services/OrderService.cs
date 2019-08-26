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
    }
}

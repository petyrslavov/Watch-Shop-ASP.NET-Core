using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchShop.Services.ServicesModels;
using WatchShop.Web.Data;

namespace WatchShop.Services
{
    public class CartService : ICartService
    {
        private readonly IMapper mapper;
        public WatchShopDbContext context { get; set; }


        public CartService(WatchShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<ProductServiceViewModel> GetUserCart(string id)
        {
            var cart = this.context.Carts
                .Include(p => p.Products)
                .ThenInclude(p => p.Product)
                .SingleOrDefault(p => p.Id == id);

            var products = cart.Products
                .Select(p => p.Product)
                .ToList();

            var model = mapper.Map<IEnumerable<ProductServiceViewModel>>(products);

            return model;
        }

        public void RemoveProductFromCart(string id)
        {
            var productToRemove = this.context.CartItems
               .Include(p => p.Product)
               .FirstOrDefault(p => p.ProductId == id);

            this.context.CartItems.Remove(productToRemove);
            this.context.SaveChanges();
        }
    }
}

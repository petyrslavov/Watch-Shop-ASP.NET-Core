using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WatchShop.Models;

namespace WatchShop.Web.Data
{
    public class WatchShopDbContext : IdentityDbContext<User>
    {
        public WatchShopDbContext(DbContextOptions<WatchShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<PendingOrder> PendingOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            base.OnModelCreating(builder);
        }
    }
}

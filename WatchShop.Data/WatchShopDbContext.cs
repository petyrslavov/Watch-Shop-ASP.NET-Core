using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            base.OnModelCreating(builder);
        }

        //public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<WatchShopDbContext>
        //{
        //    WatchShopDbContext IDesignTimeDbContextFactory<WatchShopDbContext>.CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<WatchShopDbContext>();
        //        optionsBuilder.UseSqlServer<WatchShopDbContext>("Server = (localdb)\\mssqllocaldb; Database = MyDatabaseName; Trusted_Connection = True; MultipleActiveResultSets = true");

        //        return new WatchShopDbContext(optionsBuilder.Options);
        //    }
        //}

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WatchShop.Web.Data;

namespace WatchShop.Tests.Common
{
    public static class WatchShopDbContextInMemoryFactory
    {
       public static WatchShopDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<WatchShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new WatchShopDbContext(options);

            return context;
        }
    }
}

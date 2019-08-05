using System;
using System.Collections.Generic;
using System.Text;
using WatchShop.Web.Data;

namespace WatchShop.Services
{
    public abstract class DbService
    {
        protected WatchShopDbContext context { get; set; }

        protected DbService(WatchShopDbContext context)
        {
            this.context = context;
        }
    }
}

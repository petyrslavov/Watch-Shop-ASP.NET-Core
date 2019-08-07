using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.Models;
using WatchShop.Web.Areas.Admin.Models.ViewModels;
using WatchShop.Web.Models.ViewModels;

namespace WatchShop.Web.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>();

            CreateMap<Product, ProductDetailsViewModel>();

            CreateMap<Cart, CartViewModel>();

            CreateMap<PendingOrder, OrdersViewModel>();
        }
    }
}

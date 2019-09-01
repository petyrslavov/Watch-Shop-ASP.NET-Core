using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.Models;
using WatchShop.Services.ServicesModels;
using WatchShop.Web.Areas.Admin.Models.ViewModels;
using WatchShop.Web.Models.BindingModels;
using WatchShop.Web.Models.ViewModels;

namespace WatchShop.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductServiceViewModel>();

            CreateMap<Product, ProductServiceDetailsViewModel>();

            CreateMap<Cart, CartViewModel>();

            CreateMap<PendingOrder, OrdersViewModel>()
                .ForMember(i => i.Items, d => d.MapFrom(p => p.Items));

            CreateMap<OrderServiceBindingModel, PendingOrder>();

            //CreateMap<CreateServiceBindingModel, Product>()
            // .ForMember(dest => dest.Category, opt => opt.MapFrom(c => c.Category));

        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WatchShop.Models;
using WatchShop.Services.ServicesModels;

namespace WatchShop.Tests.Common
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration((cfg =>
            {
                cfg.CreateMap<Product, ProductServiceViewModel>();
                cfg.CreateMap<Product, ProductServiceDetailsViewModel>();

            })).CreateMapper();
        }
    }
}

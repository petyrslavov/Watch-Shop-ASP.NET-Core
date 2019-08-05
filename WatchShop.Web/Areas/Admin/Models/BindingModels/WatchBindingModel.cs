using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.Models;

namespace WatchShop.Web.Areas.Admin.Models.BindingModels
{
    public class WatchBindingModel
    {
        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Category { get; set; }

    }
}

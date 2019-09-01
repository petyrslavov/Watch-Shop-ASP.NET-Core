using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WatchShop.Models;

namespace WatchShop.Services.ServicesModels
{
    public class CreateServiceBindingModel
    {
        public string Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public string CategoryId { get; set; }

        public CategoryServiceBindingModel Category { get; set; }

    }
}

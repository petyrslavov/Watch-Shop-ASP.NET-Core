using System.ComponentModel.DataAnnotations;

namespace WatchShop.Web.Models.BindingModels
{
    public class OrderBindingModel
    {
        [Required]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}

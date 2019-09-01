using System;
using System.Collections.Generic;
using System.Text;
using WatchShop.Services.ServicesModels;

namespace WatchShop.Services
{
    public interface IProductService
    {
        IEnumerable<ProductServiceViewModel> GetAllProducts();

        ProductServiceDetailsViewModel GetProductDetails(string id);

        IEnumerable<ProductServiceViewModel> GetProductsByCategory(string category);

        IEnumerable<ProductServiceViewModel> SearchProduct(string searchTerm);

        //void CreateWatch(CreateServiceBindingModel model);
    }
}

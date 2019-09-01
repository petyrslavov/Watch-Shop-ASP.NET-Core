using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchShop.Models;
using WatchShop.Services;
using WatchShop.Services.ServicesModels;
using WatchShop.Tests.Common;
using WatchShop.Web.Data;
using Xunit;

namespace WatchShop.Tests.Service
{
    public class ProductServiceTests
    {
        private IProductService productService;

        private List<Product> GetDummyData()
        {
            return new List<Product>()
            {
                new Product
                {
                    Model = "G Shock",
                    Price = 50,
                    Image = "src/pic/somepic",
                    Description = "sadasdada",
                    Category = new Category
                    {
                        Name = "Men"
                    },
                }
            };
            }

        private void SeedData(WatchShopDbContext context)
        {
            context.AddRange(GetDummyData());
            context.SaveChanges();
        }

        [Fact]
        public void GetAllProducts_WithDummyData_ShouldReturnCorrectResult()
        {
            var mapper = AutoMapperConfig.Initialize();
            string errorMessage = "ProductService GetAllProducts() method does not work properly.";

            var context = WatchShopDbContextInMemoryFactory.InitializeContext();
            SeedData(context);

            this.productService = new ProductService(context, mapper);

            List<ProductServiceViewModel> actualResults = this.productService
                .GetAllProducts()
                .ToList();

            List<ProductServiceViewModel> expectedResults = mapper
                .Map<IEnumerable<ProductServiceViewModel>>(GetDummyData())
                .ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Model == actualEntry.Model, errorMessage + " " + "Model is not returned properly");
                Assert.True(expectedEntry.Image == actualEntry.Image, errorMessage + " " + "Image is not returned properly");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessage + " " + "Price is not returned properly");
            }
        }

        [Fact]
        public void GetAllProducts_WithZeroData_ShouldReturnEmptyResults()
        {
            var mapper = AutoMapperConfig.Initialize();
            string errorMessage = "ProductService GetAllProducts() method does not work properly.";

            var context = WatchShopDbContextInMemoryFactory.InitializeContext();

            this.productService = new ProductService(context, mapper);

            List<ProductServiceViewModel> actualResults = this.productService
                .GetAllProducts()
                .ToList();

            Assert.True(actualResults.Count == 0, errorMessage);
        }

        [Fact]
        public void GetProductDetails_WithExistentId_ShouldReturnCorrentResult()
        {
            var mapper = AutoMapperConfig.Initialize();
            string errorMessage = "ProductService GetProductDetails() method does not work properly.";

            var context = WatchShopDbContextInMemoryFactory.InitializeContext();
            SeedData(context);

            this.productService = new ProductService(context, mapper);

            ProductServiceDetailsViewModel expectedEntry = mapper.Map<ProductServiceDetailsViewModel>(context.Products.First());
            ProductServiceDetailsViewModel actualEntry = this.productService.GetProductDetails(expectedEntry.Id);

            Assert.True(expectedEntry.Id == actualEntry.Id, errorMessage + " " + "Id is not returned properly");
            Assert.True(expectedEntry.Description == actualEntry.Description, errorMessage + " " + "Description is not returned properly");
            Assert.True(expectedEntry.Category.Name == actualEntry.Category.Name, errorMessage + " " + "Category is not returned properly");
            Assert.True(expectedEntry.Model == actualEntry.Model, errorMessage + " " + "Model is not returned properly");
            Assert.True(expectedEntry.Image == actualEntry.Image, errorMessage + " " + "Image is not returned properly");
            Assert.True(expectedEntry.Price == actualEntry.Price, errorMessage + " " + "Price is not returned properly");
        }

        [Fact]
        public void GetProductDetails_WithNonExistentId_ShouldReturnNull()
        {
            var mapper = AutoMapperConfig.Initialize();
            string errorMessage = "ProductService GetProductDetails() method does not work properly.";

            var context = WatchShopDbContextInMemoryFactory.InitializeContext();
            SeedData(context);

            this.productService = new ProductService(context, mapper);

            ProductServiceDetailsViewModel actualEntry = this.productService.GetProductDetails("ne i id");

            Assert.True(actualEntry == null, errorMessage);
        }
    }
}

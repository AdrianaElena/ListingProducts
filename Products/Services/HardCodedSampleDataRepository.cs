using Bogus;
using Products.Models;
using System;
using System.Collections.Generic;

namespace Products.Services
{
    public class HardCodedSampleDataRepository : IProductDataService
    {
        static List<ProductModel> products = new List<ProductModel>();

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            if (products.Count == 0)
            {
                products.Add(new ProductModel { Id = 1, Name = "Mouse Pad", Price = 5.99m, Description = "A square piece of plastic :))" });
                products.Add(new ProductModel { Id = 2, Name = "Web Cam", Price = 34.69m, Description = "Enables you to attend more Zoom meetings :)" });

                for (int i = 0; i < 100; i++)
                {
                    products.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i + 2)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Rant.Review())
                        );
                }
            }


            return products;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}

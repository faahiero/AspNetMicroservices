using System.Collections.Generic;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            var existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }
        
        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602f1b0b9b1b9c0b1c8c1b1b",
                    Name = "Iphone X",
                    Summary = "This is an awesome product",
                    Description = "This is an awesome product",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602f1b0b9b1b9c0b1c8c1b1c",
                    Name = "Samsung 10",
                    Summary = "This is an awesome product",
                    Description = "This is an awesome product",
                    ImageFile = "product-2.png",
                    Price = 900.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602f1b0b9b1b9c0b1c8c1b1d",
                    Name = "Huawei Plus",
                    Summary = "This is an awesome product",
                    Description = "This is an awesome product",
                    ImageFile = "product-3.png",
                    Price = 750.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602f1b0b9b1b9c0b1c8c1b1e",
                    Name = "Xiaomi Redmi",
                    Summary = "This is an awesome product",
                    Description = "This is an awesome product",
                    ImageFile = "product-4.png",
                    Price = 650.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602f1b0b9b1b9c0b1c8c1b1f",
                    Name = "Xiaomi Mi 10",
                    Summary = "This is an awesome product",
                    Description = "This is an awesome product",
                    ImageFile = "product-5.png",
                    Price = 850.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602f1b0b9b1b9c0b1c8c1b20",
                    Name = "Xiaomi Mi 10 Pro",
                    Summary = "This is an awesome product",
                    Description = "This is an awesome product",
                    ImageFile = "product-6.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602f1b0b9b1b9c0b1c8c1b21",
                    Name = "Xiaomi Mi 10 Ultra",
                    Summary = "This is an awesome product",
                    Description = "This is an awesome product",
                    ImageFile = "product-7.png",
                    Price = 1050.00M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}
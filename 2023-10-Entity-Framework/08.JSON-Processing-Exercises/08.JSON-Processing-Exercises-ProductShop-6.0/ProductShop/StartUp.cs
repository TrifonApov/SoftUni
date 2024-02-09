<<<<<<< HEAD
﻿namespace ProductShop
=======
﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
{
    public class StartUp
    {
        public static void Main()
        {
<<<<<<< HEAD
=======
            ProductShopContext context = new ProductShopContext();

            //string usersJson = File.ReadAllText(@"../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, usersJson));

            //string productJson = File.ReadAllText(@"../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, productJson));

            //string categoriesJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, categoriesJson));

            //string categoriesProductsJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJson));

            //Console.WriteLine(GetProductsInRange(context));
            Console.WriteLine(GetSoldProducts(context));

        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);

            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);

            context.SaveChanges();
            return $"Successfully imported {products.Length}";
        }

        private static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);

            foreach (var category in categories)
            {
                if (category.Name == null) continue;
                context.Categories.Add(category);
            }

            context.SaveChanges();
            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProcuts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoriesProducts.AddRangeAsync(categoriesProcuts);

            context.SaveChanges();
            return $"Successfully imported {categoriesProcuts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .ToList();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName,
                        })
                        .ToArray()
                })
                .OrderBy(u => u.lastName)
                    .ThenBy(u => u.firstName)
                .ToArray();


            string usersJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            return usersJson;
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
        }
    }
}
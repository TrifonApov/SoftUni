using System.Xml.Linq;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //string inputUsers = File.ReadAllText(@"../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context,inputXml));

            //string inputProducts = File.ReadAllText(@"../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, inputProducts));

            //string inputCategories = File.ReadAllText(@"../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, inputCategories));

            //string inputCategoriesProducts = File.ReadAllText(@"../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, inputCategoriesProducts));

            Console.WriteLine(GetProductsInRange(context));
        }

        #region Import
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XDocument document = XDocument.Parse(inputXml);

            var users = document.Root.Elements();
            var usersToAdd = new List<User>();
            
            foreach (var user in users)
            {
                User newUser = new User()
                {
                    FirstName = user.Element("firstName").Value,
                    LastName = user.Element("lastName").Value,
                    Age = int.Parse(user.Element("age").Value)
                };
                usersToAdd.Add(newUser);
            }

            context.Users.AddRange(usersToAdd);
            context.SaveChanges();
            return $"Successfully imported {usersToAdd.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XDocument document = XDocument.Parse(inputXml);

            var products = document.Root.Elements();
            var productsToAdd = new List<Product>();

            foreach (var product in products)
            {
                var buyerId = product.Element("buyerId");

                Product newProduct = new Product
                {
                    Name = product.Element("name").Value,
                    Price = decimal.Parse(product.Element("price").Value),
                    SellerId = int.Parse(product.Element("sellerId").Value),
                    BuyerId = buyerId != null ? int.Parse(buyerId.Value) : null
                };
                productsToAdd.Add(newProduct);
            }

            context.Products.AddRange(productsToAdd);
            context.SaveChanges();

            return $"Successfully imported {productsToAdd.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XDocument document = XDocument.Parse(inputXml);
            
            var categories = document.Root.Elements();
            var categoriesToAdd = new List<Category>();

            foreach (var product in categories)
            {
                Category newCategory = new Category
                {
                    Name = product.Element("name").Value
                };

                categoriesToAdd.Add(newCategory);
            }

            context.Categories.AddRange(categoriesToAdd);
            context.SaveChanges();

            return $"Successfully imported {categoriesToAdd.Count}";

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XDocument document = XDocument.Parse(inputXml);

            var entries = document.Root.Elements();
            var categoriesProducts = new List<CategoryProduct>();
            foreach (var entry in entries)
            {
                int categoryId = int.Parse(entry.Element("CategoryId").Value);
                int productId = int.Parse(entry.Element("ProductId").Value);
                if (!context.Categories.Any(c => c.Id == categoryId) || !context.Products.Any(p => p.Id == productId))
                {
                    continue;
                }
                categoriesProducts.Add(new CategoryProduct()
                {
                    CategoryId = categoryId,
                    ProductId = productId
                });

            }

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }
        #endregion

        #region Export

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p=> new
                {
                    name = p.Name,
                    price = p.Price,
                    buyer = p.Buyer.FirstName + " " + p.Buyer.LastName,
                })
                .OrderBy(p=>p.price)
                .Take(10)
                .ToList();

            var serializer = new XmlSerializer(typeof(Product));
            using (var writer = new StreamWriter("myProduct.xml"))
            {
                serializer.Serialize(writer, Console.Out);
            }

            Console.WriteLine();
            return "";
        }

        #endregion
    }
}
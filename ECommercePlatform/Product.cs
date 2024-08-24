using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform
{
    public class Product
    {
        private static readonly string[] Categories;


        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }


        static void DisplayProductDetails(Product product)
        {
            Console.WriteLine($"ProductID:: {product.ProductId}, Name:: {product.Name}, Category:: {product.Category}, Price:: {product.Price}, Stock:: {product.StockQuantity}");
        }

        static void UpdatePrice(Product product, decimal newPrice)
        {
            try
            {
                product.Price = newPrice;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Price Update Error:: {ex.Message}");
            }
        }

        static void SetStockQuantity(Product product, int newQuantity)
        {
            try
            {
                product.StockQuantity = newQuantity;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Stock Update Error:: {ex.Message}");
            }



        }


        static Product()
        {

            Categories = new string[] { "Electronics", "Clothing", "Books", "Accessories" };
            Console.WriteLine("Static constructor called: Categories initialized.");
        }


        public Product(int productId, string name, string category, decimal price, int stockQuantity)
        {
            ProductId = productId;
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;


            Validate();
        }


        public Product(Product existingProduct)
        {
            ProductId = existingProduct.ProductId;
            Name = existingProduct.Name;
            Category = existingProduct.Category;
            Price = existingProduct.Price;
            StockQuantity = existingProduct.StockQuantity;
        }


        private void Validate()
        {
            bool isValid = true;


            if (ProductId <= 0)
            {
                Console.WriteLine("Invalid ProductId. Setting to default value 1.");
                ProductId = 1;
                isValid = false;
            }

            if (Price <= 0)
            {
                Console.WriteLine("Invalid Price. Setting to default value 1.00.");
                Price = 1.00m;
                isValid = false;
            }


            if (StockQuantity < 0)
            {
                Console.WriteLine("Invalid StockQuantity. Setting to default value 0.");
                StockQuantity = 0;
                isValid = false;
            }

            if (!isValid)
            {
                Console.WriteLine("Some product data was invalid and has been adjusted.");
            }
        }
    }
}

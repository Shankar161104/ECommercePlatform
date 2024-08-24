using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform
{

    public class FileHandler
    {
        private string productsFile = "products.txt";
        private string ordersFile = "orders.txt";
        private string reviewsFile = "reviews.txt";

        public void SaveProducts(List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(productsFile))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.ProductId},{product.Name},{product.Category},{product.Price},{product.StockQuantity}");
                }
            }
        }

        public List<Product> LoadProducts()
        {
            var products = new List<Product>();

            using (StreamReader reader = new StreamReader(productsFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    var product = new Product(
                        int.Parse(parts[0]),
                        parts[1],
                        parts[2],
                        decimal.Parse(parts[3]),
                        int.Parse(parts[4])
                    );
                    products.Add(product);
                }
            }

            return products;
        }

        
    }
}

using ECommercePlatform.ECommercePlatform;
using System;
using System.Collections.Generic;

namespace ECommercePlatform
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Product objProduct1 = new Product(1, "Samsung Galaxy 15 pro", "Electronics", 128000, 10);
            Product objProduct2 = new Product(2, "Headphones", "Electronics", 150, 5);
            Product objProduct3 = new Product(3, "Grinder", "Home Appliances", 25, 50);


            List<Product> productsList = new List<Product> { objProduct1, objProduct2, objProduct3 };

           
            var orderedProducts = new List<(Product product, int quantity)>
            {
                (objProduct1, 1),
                (objProduct2, 2)
            };
            var order = new Order(1, 101, orderedProducts, DateTime.Now);

         
            var customer = new Customer
            {
                CustomerId = 101,
                Name = "Jai Shankar",
                Email = "jai shankar@example.com"
            };

      
            var orderService = new OrderService();
            orderService.NotifyDepartments += message => Console.WriteLine($"Notification: {message}");

            var fileHandler = new FileHandler();
            var reflectionExample = new ReflectionExample();

            while (true)
            {
              
                Console.WriteLine("\nSelect an operation:");
                Console.WriteLine("1. Display all products");
                Console.WriteLine("2. Add a product to the order");
                Console.WriteLine("3. Remove a product from the order");
                Console.WriteLine("4. View customer order history and reviews");
                Console.WriteLine("5. Place a new order");
                Console.WriteLine("6. Add a new product");
                Console.WriteLine("7. Save products to file");
                Console.WriteLine("8. Load products from file");
                Console.WriteLine("9. Exit");

          
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

               
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n====================All Products:====================");
                        foreach (var product in productsList)
                        {
                            Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Category: {product.Category}, Price: {product.Price}, Stock: {product.StockQuantity}");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nEnter Product ID to add to order:");
                        int addProductId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter quantity:");
                        int quantityToAdd = int.Parse(Console.ReadLine());
                        var productToAdd = productsList.Find(p => p.ProductId == addProductId);
                        if (productToAdd != null)
                        {
                            order.AddProduct(productToAdd, quantityToAdd);
                            Console.WriteLine($"Added {quantityToAdd} of {productToAdd.Name} to the order.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nEnter Product ID to remove from order:");
                        int removeProductId = int.Parse(Console.ReadLine());
                        var productToRemove = productsList.Find(p => p.ProductId == removeProductId);
                        if (productToRemove != null)
                        {
                            order.RemoveProduct(productToRemove);
                            Console.WriteLine($"Removed {productToRemove.Name} from the order.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;

                    case "4":
                        Console.WriteLine($"\nCustomer ID: {customer.CustomerId}, Name: {customer.Name}, Email: {customer.Email}");
                        Console.WriteLine("Order History:");
                        foreach (var custOrder in customer.OrderHistory)
                        {
                            Console.WriteLine($"OrderId: {custOrder.OrderId}, TotalAmount: {custOrder.TotalAmount}");
                        }
                        Console.WriteLine("Reviews:");
                        foreach (var custReview in customer.Reviews)
                        {
                            Console.WriteLine($"ReviewId: {custReview.ReviewId}, ProductId: {custReview.ProductId}, Rating: {custReview.Rating}, Comment: {custReview.Comment}");
                        }
                        break;

                    case "5":
                        Console.WriteLine("\nPlacing a new order...");
                        var newProducts = new List<(Product product, int quantity)>
                        {
                            (objProduct3, 2)
                        };
                        orderService.PlaceOrder(customer, newProducts);
                        Console.WriteLine("Order placed successfully.");
                        break;

                    case "6":
                        Console.WriteLine("\nEnter details of the new product:");
                        Console.Write("Product ID: ");
                        int newProductId = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Category: ");
                        string newCategory = Console.ReadLine();
                        Console.Write("Price: ");
                        decimal newPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Stock Quantity: ");
                        int newStockQuantity = int.Parse(Console.ReadLine());

                        var newProduct = new Product(newProductId, newName, newCategory, newPrice, newStockQuantity);
                        productsList.Add(newProduct);
                        Console.WriteLine($"New product '{newName}' added successfully.");
                        break;

                    case "7":
                        fileHandler.SaveProducts(productsList);
                        Console.WriteLine("Products saved to file.");
                        break;

                    case "8":
                        var loadedProducts = fileHandler.LoadProducts();
                        Console.WriteLine("\n==============Products loaded from file:==================");
                        foreach (var p in loadedProducts)
                        {
                            Console.WriteLine($"ProductId: {p.ProductId}, Name: {p.Name}, Category: {p.Category}, Price: {p.Price}, Stock: {p.StockQuantity}");
                        }
                        break;

                    case "9":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

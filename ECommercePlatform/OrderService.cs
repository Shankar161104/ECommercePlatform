using ECommercePlatform.ECommercePlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform
{
    public partial class OrderService
    {
       
        public delegate void NotificationDelegate(string message);

      
        public NotificationDelegate NotifyDepartments;

      
        public void PlaceOrder(Customer customer, List<(Product product, int quantity)> products)
        {
            var order = new Order(GetNextOrderId(), customer.CustomerId, products, DateTime.Now);

            foreach (var product in products)
            {
                product.product.StockQuantity -= product.quantity;
            }

            customer.OrderHistory.Add(order);

            NotifyDepartments?.Invoke("A new order has been placed!");

         
            LogChanges("Order placed: " + order.OrderId);
        }

       
        public void AddReview(Customer customer, Product product, int rating, string comment)
        {
            var review = new Review(GetNextReviewId(), product.ProductId, customer.CustomerId, rating, comment);
            customer.AddReview(review);

            NotifyDepartments?.Invoke("A new review has been added!");

           
            LogChanges("Review added: " + review.ReviewId);
        }


        private int GetNextOrderId()
        {
            
            return new Random().Next(1, 1000); 
        }

      
        private int GetNextReviewId()
        {
            
            return new Random().Next(1, 1000); 
        }
       private void LogChanges(string message)
        {
            Console.WriteLine("Log: " + message);
        }
    }
}

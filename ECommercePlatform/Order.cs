using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace ECommercePlatform
    {
        public class Order
        {
         
            public int OrderId { get; set; }
            public int CustomerId { get; set; }
            public List<(Product product, int quantity)> OrderedProducts { get; set; } = new List<(Product, int)>();
            public DateTime OrderDate { get; set; }
            public decimal TotalAmount => CalculateTotalAmount();

            public Order(int orderId, int customerId, List<(Product product, int quantity)> orderedProducts, DateTime orderDate)
            {
                OrderId = orderId;
                CustomerId = customerId;
                OrderedProducts = orderedProducts;
                OrderDate = orderDate;

                if (OrderDate > DateTime.Now)
                    throw new ArgumentException("OrderDate cannot be in the future.");
            }

            public void AddProduct(Product product, int quantity)
            {
                OrderedProducts.Add((product, quantity));
            }

            public void RemoveProduct(Product product)
            {
                OrderedProducts.RemoveAll(p => p.product.ProductId == product.ProductId);
            }

            private decimal CalculateTotalAmount()
            {
                return OrderedProducts.Sum(p => p.product.Price * p.quantity);
            }
        }
    }


}

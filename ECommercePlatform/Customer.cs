using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform
{
    using System;
    using System.Collections.Generic;

    namespace ECommercePlatform
    {
        public class Customer
        {
           
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public List<Order> OrderHistory { get; set; } = new List<Order>();
            public List<Review> Reviews { get; set; } = new List<Review>();

           
            public void UpdateCustomerInfo(string _name, string _email)
            {
                Name = _name;
                Email = _email;
            }

            
            public List<Order> GetOrderHistory()
            {
                return OrderHistory;
            }

            
            public void AddReview(Review review)
            {
                Reviews.Add(review);
            }
        }
    }




  
}

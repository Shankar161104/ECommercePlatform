using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform
{
    public class Review
    {

        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }


        public Review(int reviewId, int productId, int customerId, int rating, string comment)
        {
            ReviewId = reviewId;
            ProductId = productId;
            CustomerId = productId;
            CustomerId = customerId;


            Rating = ValidateRating(rating) ? rating : 1;
            Comment = ValidateComment(comment) ? comment : "No comment provided.";
        }

        private bool ValidateRating(int rating)
        {
            return rating >= 1 && rating <= 5;
        }

        private bool ValidateComment(string comment)
        {
            return !string.IsNullOrWhiteSpace(comment);
        }

    }
}

using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        // Promotion details specific to the book
        public bool IsOnPromotion { get; set; } // Flag to indicate if the book is on promotion
        public decimal? DiscountPercentage { get; set; } // Discount percentage specific to the book
        public string PromotionDescription { get; set; } // Description of the promotion (optional)

       
        public const int MinimumQuantity = 1;
        public const int MaximumQuantity = 20;



        [Key]
        public string ISBN { get; set; }

        public Publisher Publisher { get; set; } // Reference to the publisher

        public List<BookAuthor> Authors { get; set; }

        public int PublisherId { get; set; } // Foreign key of publisher

        public int OrderId { get; set; } // Order ID reference

        // Method to calculate the final base price using Publisher's base price
        public decimal GetBasePrice()
        {
            // Start with the base price set by the publisher
            decimal finalPrice = Publisher.GetBasePrice();

            // Apply book-specific promotions if available
            if (IsOnPromotion && DiscountPercentage.HasValue && DiscountPercentage.Value > 0)
            {
                finalPrice -= (finalPrice * DiscountPercentage.Value / 100);
            }

            return finalPrice;
        }

        // Method to return the final price (after all discounts)
        public decimal GetTotalPrice()
        {
            return GetBasePrice();
        }

        // Method to get formatted total price (for UI purposes)
        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }
    }
}

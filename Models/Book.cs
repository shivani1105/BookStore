using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        // Promotion details specific to the book
        public bool IsOnPromotion { get; set; } // Flag to indicate if the book is on promotion
        public decimal? DiscountPercentage { get; set; } // Discount percentage specific to the book
        public string PromotionCode { get; set; } // Code for additional discount (optional)



        public const int MinimumQuantity = 1;
        public const int MaximumQuantity = 5;



        [Key]
        public string ISBN { get; set; }

        public Publisher Publisher { get; set; } // Reference to the publisher

        public List<BookAuthor> Authors { get; set; }

        public int PublisherId { get; set; } // Foreign key of publisher

        public int Quantity { get; set; }

        public int OrderId { get; set; } // Order ID reference

        // Predefined promotion codes and their discount percentages
        private static Dictionary<string, decimal> PromotionCodes = new Dictionary<string, decimal>
        {
            { "NEWYEAR", 10m },  // 10% discount for NEWYEAR promotion
            { "SUMMER20", 15m }, // 15% discount for SUMMER20
            { "FALLSALE", 12m }, // 20% discount for FALLSALE
        };

        // Method to calculate the final base price using Publisher's base price
        public decimal GetBasePrice()
        {
            // Start with the base price set by the publisher
            decimal finalPrice = Publisher.GetBasePrice();

            // Apply the book-specific promotions if available
            if (IsOnPromotion)
            {
                // Set the DiscountPercentage based on the PromotionCode
                if (!string.IsNullOrEmpty(PromotionCode) && PromotionCodes.ContainsKey(PromotionCode.ToUpper()))
                {
                    DiscountPercentage = PromotionCodes[PromotionCode.ToUpper()];
                }

                // Apply the discount if DiscountPercentage has a value
                if (DiscountPercentage.HasValue && DiscountPercentage.Value > 0)
                {
                    finalPrice -= (finalPrice * DiscountPercentage.Value / 100);
                }
            }

            return finalPrice * Quantity;
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

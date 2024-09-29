namespace BookStore.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; } // Cost to produce the book (for internal purposes)

        public decimal Retail { get; set; } // Suggested retail price (used for BasePrice)

        public decimal Discount { get; set; } // Publisher's Discount (if any)

        public string Title { get; set; }

        public DateTime PubDate { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public int? FixedQuantity { get; set; } // Can be ignored if not used

        // Method to calculate the base price using Retail and Discount
        public decimal GetBasePrice()
        {
            // Check if there is a discount available
            if (Discount > 0)
            {
                // Apply the discount to the retail price
                return Retail - (Retail * Discount / 100);
            }

            // If no discount, return the retail price as the base price
            return Retail;
        }

        // Method to get formatted base price (for UI purposes)
        public string GetFormattedBasePrice() => GetBasePrice().ToString("0.00");
    }
}

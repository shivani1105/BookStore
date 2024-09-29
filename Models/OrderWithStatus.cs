namespace BookStore.Models
{
    public class OrderWithStatus
    {
        // Instead of preparation, we use "Processing" and "Shipping" durations
        public readonly static TimeSpan ProcessingDuration = TimeSpan.FromHours(2); // Simulated processing time
        public readonly static TimeSpan ShippingDuration = TimeSpan.FromDays(3); // Simulated shipping duration

        public Order Order { get; set; }

        public string StatusText { get; set; }

        public bool IsDelivered => StatusText == "Delivered";

        // Method to create OrderWithStatus from an order
        public static OrderWithStatus FromOrder(Order order)
        {
            // Status updates based on time since order was created
            string statusText;
            var processingTime = order.CreatedTime.Add(ProcessingDuration);
            var shippingTime = processingTime.Add(ShippingDuration);

            if (DateTime.Now < processingTime)
            {
                statusText = "Processing";
            }
            else if (DateTime.Now < shippingTime)
            {
                statusText = "Shipped";
            }
            else
            {
                statusText = "Delivered";
            }

            return new OrderWithStatus
            {
                Order = order,
                StatusText = statusText
            };
        }
    }
}

namespace BookStore.Models
{
    public class Customer
    {
        public bool IsAuthenticated { get; set; }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}

namespace E_CommerceNoStripe.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }


        // Nav properties
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
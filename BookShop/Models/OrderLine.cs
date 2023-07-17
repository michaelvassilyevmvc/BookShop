namespace BookShop.Models
{
    public class OrderLine
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}

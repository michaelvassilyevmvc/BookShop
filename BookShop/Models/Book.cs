using System;

namespace BookShop.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedOn{ get; set; }
    }
}

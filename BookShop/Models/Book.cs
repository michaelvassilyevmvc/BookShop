using System;

namespace BookShop.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal RetailPrice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime PublishedOn{ get; set; }
    }
}

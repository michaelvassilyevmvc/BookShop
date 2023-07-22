using System.Collections.Generic;
using System.Linq;

namespace BookShop.Models
{
    public class Cart
    {
        private List<OrderLine> selections = new List<OrderLine>();

        public Cart AddItem(Book b, int quantity)
        {
            OrderLine line = selections.Where(l => l.BookId == l.Id).FirstOrDefault();
            if (line != null)
            {
                line.Quantity += quantity;
            }
            else
            {
                selections.Add(new OrderLine {  BookId = b.Id, Book = b, Quantity = quantity });
            }
            return this;
        }

        public Cart RemoveItem(long bookId)
        {
            selections.RemoveAll(l => l.BookId == bookId);
            return this;
        }

        public void Clear() => selections.Clear();

        public IEnumerable<OrderLine> Selections { get => selections; }
    }
}

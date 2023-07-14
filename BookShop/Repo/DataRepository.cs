using BookShop.Models;
using System.Collections.Generic;

namespace BookShop.Repo
{
    public class DataRepository : IRepository
    {
        private List<Book> data = new List<Book>();

        public IEnumerable<Book> Books => data;

        public void AddBook(Book book)
        {
            this.data.Add(book);
        }
    }
}

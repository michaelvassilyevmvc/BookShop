using BookShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Repo
{
    public class DataRepository : IRepository
    {
        private DataContext _context;

        public DataRepository(DataContext context) => _context = context;

        public IEnumerable<Book> Books => _context.Books.ToArray();

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book GetBook(int key) => _context.Books.Find(key);

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}

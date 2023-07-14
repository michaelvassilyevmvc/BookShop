using BookShop.Models;
using System.Collections.Generic;

namespace BookShop.Repo
{
    public interface IRepository
    {
        IEnumerable<Book> Books { get; }
        void AddBook(Book book);
    }
}

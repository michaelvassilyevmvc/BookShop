using BookShop.Models;
using System.Collections.Generic;

namespace BookShop.Repo
{
    public interface IRepository
    {
        IEnumerable<Book> Books { get; }
        void AddBook(Book book);
        Book GetBook(int key);
        void UpdateBook(Book book);
        void UpdateAll(Book[] books);
        void DeleteBook(Book book);
    }
}

using BookShop.Models;
using BookShop.Models.Pages;
using System.Collections.Generic;

namespace BookShop.Repo
{
    public interface IRepository
    {
        IEnumerable<Book> Books { get; }
        PagedList<Book> GetBooks(QueryOptions options);
        void AddBook(Book book);
        Book GetBook(int key);
        void UpdateBook(Book book);
        void UpdateAll(Book[] books);
        void DeleteBook(Book book);
    }
}

﻿using BookShop.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookShop.Models.Pages;

namespace BookShop.Repo
{
    public class DataRepository : IRepository
    {
        private DataContext _context;

        public DataRepository(DataContext context) => _context = context;

        public IEnumerable<Book> Books => _context.Books.Include(x => x.Category);

        public PagedList<Book> GetBooks(QueryOptions options, int categoryId = 0)
        {
            IQueryable<Book> query = _context.Books.Include(x => x.Category);
            if(categoryId != 0)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }

            return new PagedList<Book>(query, options);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Book GetBook(int key) => _context.Books.Include(x => x.Category).First(x=>x.Id == key);

        public void UpdateAll(Book[] books)
        {
            Dictionary<int,Book> data = books.ToDictionary(b => b.Id);
            IEnumerable<Book> baseline = _context.Books.Where(b =>  data.Keys.Contains(b.Id));

            foreach (Book book in baseline)
            {
                Book requestBook = data[book.Id];
                book.Title = requestBook.Title;
                book.Category = requestBook.Category;
                book.Price  = requestBook.Price;
                book.RetailPrice = requestBook.RetailPrice;
                book.PublishedOn = requestBook.PublishedOn;
            }

            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            var b = GetBook(book.Id);
            b.Title = book.Title;
            b.Category = book.Category;
            b.Price = book.Price;
            b.RetailPrice = book.RetailPrice;
            b.PublishedOn = book.PublishedOn;

            _context.SaveChanges();
        }


    }
}

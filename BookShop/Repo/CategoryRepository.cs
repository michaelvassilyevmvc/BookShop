using System.Collections.Generic;
using BookShop.Models;
using BookShop.Models.Pages;

namespace BookShop.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public IEnumerable<Category> Categories => _context.Categories;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context?.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public PagedList<Category> GetCategories(QueryOptions options)
        {
            return new PagedList<Category>(_context.Categories, options);
        }
    }
}

using System.Collections.Generic;
using BookShop.Models;
using BookShop.Models.Pages;

namespace BookShop.Repo
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        PagedList<Category> GetCategories(QueryOptions options);

        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}

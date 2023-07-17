using System.Collections.Generic;
using BookShop.Models;

namespace BookShop.Repo
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}

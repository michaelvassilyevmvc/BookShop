using BookShop.Models;
using BookShop.Models.Pages;
using System.Collections.Generic;

namespace BookShop.Repo
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        User Get(string login, string password);
        PagedList<User> GetUsers(QueryOptions options);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
  
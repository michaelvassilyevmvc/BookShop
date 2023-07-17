using BookShop.Models;
using System.Collections.Generic;

namespace BookShop.Repo
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        User Get(string login, string password);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
  
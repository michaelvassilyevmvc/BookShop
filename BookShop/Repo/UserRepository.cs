using BookShop.Models;
using BookShop.Models.Pages;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext _context)
        {
            this._context = _context;
        }

        public IEnumerable<User> Users => _context.Users.ToArray();

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public User Get(string login, string password) => _context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);

        public PagedList<User> GetUsers(QueryOptions options) => new PagedList<User>(_context.Users, options);
        

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}

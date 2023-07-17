using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Repo
{
    public class OrderRepository : IOrdersRepository
    {
        private readonly DataContext _context;

        public IEnumerable<Order> Orders => _context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context?.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.Include(x => x.Lines).ThenInclude(x=>x.Book).First(x => x.Id.Equals(id));
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}

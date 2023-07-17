using System.Collections.Generic;
using BookShop.Models;

namespace BookShop.Repo
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> Orders { get; }

        Order GetOrder(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}

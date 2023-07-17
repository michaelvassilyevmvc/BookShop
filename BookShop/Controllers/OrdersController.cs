using BookShop.Models;
using BookShop.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Controllers
{
    public class OrdersController: Controller
    {
        private readonly IRepository _bookRepo;
        private readonly IOrdersRepository _orderRepo;

        public OrdersController(IRepository bookRepo, IOrdersRepository orderRepo)
        {
            _bookRepo = bookRepo;
            _orderRepo = orderRepo;
        }

        public IActionResult Index() => View(_orderRepo.Orders);

        public IActionResult EditOrder(int id) 
        {
            var books = _bookRepo.Books;
            Order order = id == 0 ? new Order() : _orderRepo.GetOrder(id);
            IDictionary<int, OrderLine> lineMap = order.Lines?.ToDictionary(x => x.BookId) ?? new Dictionary<int, OrderLine>();
            ViewBag.Lines = books.Select(x => lineMap.ContainsKey(x.Id) ? lineMap[x.Id] : new OrderLine { Book = x, BookId = x.Id, Quantity = 0});
            return View(order);
        }

        [HttpPost]
        public IActionResult AddOrUpdateOrder(Order order) {
            order.Lines = order.Lines.Where(l => l.Id > 0 || (l.Id == 0 && l.Quantity > 0)).ToArray();
            if(order.Id == 0)
            {
                _orderRepo.Add(order);
            } else
            {
                _orderRepo.Update(order);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteOrder(Order order) 
        {
            _orderRepo.Delete(order);
            return RedirectToAction(nameof(Index));
        }

    }
}

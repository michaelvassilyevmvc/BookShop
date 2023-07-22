using BookShop.Infrastructure;
using BookShop.Models;
using BookShop.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace BookShop.Controllers
{
    [ViewComponent(Name = "Cart")]
    public class CartController:Controller
    {
        private IRepository bookRepository;
        private IOrdersRepository orderRepository;

        public CartController(IRepository repo, IOrdersRepository orderRepo)
        {
            bookRepository = repo;
            orderRepository = orderRepo;
        }

        public IActionResult Index(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(GetCart());
        }

        [HttpPost]
        public IActionResult AddToCart(Book book, string returnUrl) {
            SaveCart(GetCart().AddItem(book, 1));
            return RedirectToAction(nameof(Index), new { returnUrl });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int bookId, string returnUrl)
        {
            SaveCart(GetCart().RemoveItem(bookId)); 
            return RedirectToAction(nameof(Index), new {returnUrl});
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            order.Lines = GetCart().Selections.Select(x => new OrderLine
            {
                BookId = x.BookId,
                Quantity = x.Quantity,
            }).ToArray();
            orderRepository.Add(order);
            SaveCart(new Cart());
            return RedirectToAction(nameof(Completed));
        }

        public IActionResult Completed() => View();

        public IViewComponentResult Invoke(ISession session)
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<Cart>(ViewData, session.GetJson<Cart>("Cart"))
            };
        }

        #region Methods

        public Cart GetCart() => HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }



        #endregion
    }
}

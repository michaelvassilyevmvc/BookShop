using BookShop.Models;
using BookShop.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repo;

        public HomeController(ILogger<HomeController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            //Console.Clear();
            return View(_repo.Books);
        }


        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _repo.AddBook(book);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult UpdateBook(int key)
        {
            return View(_repo.GetBook(key));
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            _repo.UpdateBook(book);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateAll()
        {
            ViewBag.UpdateAll = true;
            return View(nameof(Index), _repo.Books);
        }

        [HttpPost]
        public IActionResult UpdateAll(Book[] books)
        {
            _repo.UpdateAll(books);
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult DeleteBook(Book book)
        {
            _repo.DeleteBook(book);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

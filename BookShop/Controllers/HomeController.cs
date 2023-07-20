using BookShop.Models;
using BookShop.Models.Pages;
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
        private readonly ICategoryRepository _catRepo;

        public HomeController(ILogger<HomeController> logger, IRepository repo, ICategoryRepository catRepo)
        {
            _logger = logger;
            _repo = repo;
            _catRepo = catRepo;
        }

        public IActionResult Index(QueryOptions options)
        {
            //Console.Clear();
            return View(_repo.GetBooks(options));
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
            ViewBag.Categories = _catRepo.Categories;
            return View(key == 0 ? new Book() : _repo.GetBook(key));
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            if(book.Id == 0)
            {
                _repo.AddBook(book);
            }
            else
            {
                _repo.UpdateBook(book);
            }
            
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

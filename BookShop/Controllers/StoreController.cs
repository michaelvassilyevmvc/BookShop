using BookShop.Models.Pages;
using BookShop.Repo;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class StoreController: Controller
    {
        private IRepository bookRepository;
        private ICategoryRepository categoryRepository;

        public StoreController(IRepository repository, ICategoryRepository catRepo)
        {
            bookRepository = repository;
            categoryRepository = catRepo;
        }

        public IActionResult Index([FromQuery(Name = "options")] QueryOptions bookOptions, QueryOptions catOptions, int category)
        {
            ViewBag.Categories = categoryRepository.GetCategories(catOptions);
            ViewBag.SelectedCategory = category;
            return View(bookRepository.GetBooks(bookOptions, category));
        }
    }
}

using BookShop.Models;
using BookShop.Repo;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class CategoriesController:Controller
    {
        private readonly ICategoryRepository _repo;

        public CategoriesController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index() => View(_repo.Categories);

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _repo.Add(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditCategory(int id)
        {
            ViewBag.EditId = id;
            return View("Index", _repo.Categories);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _repo.Update(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category) { 
            _repo.Delete(category); 
            return RedirectToAction(nameof(Index));
        }
    }
}

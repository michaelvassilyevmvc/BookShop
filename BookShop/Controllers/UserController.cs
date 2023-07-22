using BookShop.Models;
using BookShop.Models.Pages;
using BookShop.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class UsersController:Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index(QueryOptions options) => View(_userRepository.GetUsers(options));

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if(user != null) 
            { 
                _userRepository.Add(user);
            }

            return null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if(user != null)
            {
                var getUser = _userRepository.Get(user.Login, user.Password);
                if(getUser != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }

            return RedirectToAction(nameof(Login));
            
        }
    }
}

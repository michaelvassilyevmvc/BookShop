using BookShop.Models;
using BookShop.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class UserController:Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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

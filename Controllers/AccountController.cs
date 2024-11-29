using Microsoft.AspNetCore.Mvc;
using RegisterLoginApp_ASP_MVC.Data;
using RegisterLoginApp_ASP_MVC.Models;
using System.Linq;

namespace RegisterLoginApp_ASP_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            var loggedInUser = _context.Users
                .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (loggedInUser != null)
            {
                HttpContext.Session.SetString("Username", loggedInUser.Username);
                return RedirectToAction("Welcome");
            }

            ViewBag.Message = "Geçersiz kullanıcı adı veya şifre.";
            return View();
        }


        public IActionResult Welcome()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login");
            }

            var loggedInUser = _context.Users.FirstOrDefault(u => u.Username == username);
            return View(loggedInUser);
        }

    }
}

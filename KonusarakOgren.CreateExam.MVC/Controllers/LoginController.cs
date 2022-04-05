using KonusarakOgren.CreateExam.MVC.ViewModels;
using KonusarakOgren.CreateExam.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var isUser = _userService.GetAsync(loginViewModel.Email, loginViewModel.Password);

                if (isUser != null)
                {
                    List<Claim> userClaims = new List<Claim>();

                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.Id.ToString()));
                    
                    var claimsIdentity = new ClaimsIdentity(userClaims,CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Yanlış");
                }
               
            }
            return View(loginViewModel);
        }
    }
}

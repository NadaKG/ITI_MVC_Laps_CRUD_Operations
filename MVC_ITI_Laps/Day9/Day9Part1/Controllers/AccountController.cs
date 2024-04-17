using Day9.Models;
using Day9.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Day9.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> UserManager;
        private readonly SignInManager<AppUser> SignInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registeredUser)
        {
            if (ModelState.IsValid)
            {
                AppUser userM = new AppUser();
                userM.UserName = registeredUser.UserName;
                userM.Email = registeredUser.Email;
                userM.PasswordHash = registeredUser.Password;
                userM.First_Name = registeredUser.FirstName;
                userM.Last_Name = registeredUser.LastName;
                IdentityResult result = await UserManager.CreateAsync(userM,registeredUser.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(userM,true);
                    return RedirectToAction("Index", "Trainee");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(registeredUser);
        }

        public IActionResult Logout()
        {
            SignInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
               AppUser existinguser= await UserManager.FindByNameAsync(user.UserName);
                if(existinguser != null)
                {
                  bool found= await UserManager.CheckPasswordAsync(existinguser, user.Password);
                    if(found)
                    {
                        await SignInManager.SignInAsync(existinguser, user.RememberMe);
                        return RedirectToAction("Index", "Trainee");
                    }
                }  
            }
            ModelState.AddModelError("", "Wrong User Name or Password");
            return View(user);
        }

    }
}

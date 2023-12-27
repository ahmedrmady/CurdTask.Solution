using AutoMapper;
using CurdTask.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CurdTask.PL.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        #region SignIn
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel logIn)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(logIn.Email);
                if (user is not null)
                {
                    var flag = await _userManager.CheckPasswordAsync(user, logIn.Password);
                    if (flag)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, logIn.Password,false,false);
                        if (result.Succeeded)
                            return RedirectToAction(nameof(EmployeesController.Index), "Employees");

                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid LogIn");
            }
            return View(logIn);
        }
        #endregion

        #region SignOut
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIn));
        }

        #endregion

    }
}

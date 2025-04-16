using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginVW)
    {
        if (!ModelState.IsValid)
        {
            return View(loginVW);
        }

        var user = await _userManager.FindByNameAsync(loginVW.UserName);

        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginVW.Password, false, false);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(loginVW.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(loginVW.ReturnUrl);
            }
        }
        ModelState.AddModelError("", "Falha ao realizar o login!");
        return View(loginVW);
    }
}

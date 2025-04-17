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

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(LoginViewModel registroVW)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = registroVW.UserName };
            var result = await _userManager.CreateAsync(user, registroVW.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                this.ModelState.AddModelError("Registro", "Falha ao resgistrar o usuário");
            }
        }
        return View(registroVW);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();
        HttpContext.User = null;
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}

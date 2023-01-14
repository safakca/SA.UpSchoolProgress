using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template_Design_Pattern.DAL.Entities;
using Template_Design_Pattern.Models;

namespace Template_Design_Pattern.Controllers;
public class LoginController : Controller
{

    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(UserLoginViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Default");
        }

        return View();
    }
}

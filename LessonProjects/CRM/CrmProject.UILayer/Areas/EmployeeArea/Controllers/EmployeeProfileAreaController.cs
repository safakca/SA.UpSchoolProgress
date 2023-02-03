using CrmProject.EntityLayer.Concrete;
using CrmProject.UILayer.Areas.EmployeeArea.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CrmProject.UILayer.Areas.EmployeeArea.Controllers;

[Area("EmployeeArea")]
public class EmployeeProfileAreaController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public EmployeeProfileAreaController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        UserEditProfileVM userEditProfileVM = new UserEditProfileVM();
        userEditProfileVM.Name = values.Name;
        userEditProfileVM.Surname = values.Surname;
        userEditProfileVM.PhoneNumber = values.PhoneNumber;
        userEditProfileVM.Email = values.Email;
        return View(userEditProfileVM);
    }
    [HttpPost]
    public async Task<IActionResult> Index(UserEditProfileVM userEditProfileVM)
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        if (userEditProfileVM.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extansion = Path.GetExtension(userEditProfileVM.Image.FileName);
            var imageName = Guid.NewGuid() + extansion;
            var saveLocation = resource + "/wwwroot/UserImages/" + imageName;
            var stream = new FileStream(saveLocation, FileMode.Create);
            await userEditProfileVM.Image.CopyToAsync(stream);
            values.ImageURL = imageName;
        }
        values.Name = userEditProfileVM.Name;
        values.Surname = userEditProfileVM.Surname;
        values.PhoneNumber = userEditProfileVM.PhoneNumber;
        values.Email = userEditProfileVM.Email;
        values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userEditProfileVM.Password);

        var result = await _userManager.UpdateAsync(values);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Login");
        }
        return View();
    }
}

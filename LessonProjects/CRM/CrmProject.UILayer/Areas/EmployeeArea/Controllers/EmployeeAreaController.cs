using CrmProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrmProject.UILayer.Areas.EmployeeArea.Controllers;

[Area("EmployeeArea")]
public class EmployeeAreaController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public EmployeeAreaController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.v1 = values.Name;
        ViewBag.v2 = values.Surname;

        return View();
    }
}

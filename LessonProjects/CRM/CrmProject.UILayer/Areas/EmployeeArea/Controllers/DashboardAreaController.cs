using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrmProject.UILayer.Areas.EmployeeArea.Controllers;

[Area("EmployeeArea")]
[AllowAnonymous]
public class DashboardAreaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

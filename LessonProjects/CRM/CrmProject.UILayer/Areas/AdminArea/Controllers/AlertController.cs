using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrmProject.UILayer.Areas.AdminArea.Controllers;

[Area("AdminArea")]
[AllowAnonymous]
public class AlertController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

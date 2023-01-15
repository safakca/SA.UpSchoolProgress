using CrmProject.BusinessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrmProject.UILayer.Areas.EmployeeArea.Controllers;

[Area("EmployeeArea")]
public class EmployeeTaskAreaController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmployeeTaskService _employeeTaskService;
    public EmployeeTaskAreaController(UserManager<AppUser> userManager, IEmployeeTaskService employeeTaskService)
    {
        _userManager = userManager;
        _employeeTaskService = employeeTaskService;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var taskList = _employeeTaskService.TGetEmployeeTasksByUserId(values.Id);
        return View(taskList);
    }
}

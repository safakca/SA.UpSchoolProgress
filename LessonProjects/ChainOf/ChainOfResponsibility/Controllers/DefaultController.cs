using Microsoft.AspNetCore.Mvc;
using UpSchool_ChainOfResponsibility.ChainOfResponsibility;

namespace UpSchool_ChainOfResponsibility.Controllers;
public class DefaultController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(WithdrawViewModel p)
    {
        Employee treasurer = new Treasurer();
        Employee managerAsistant = new ManagerAsistant();
        Employee manager = new Manager();
        Employee regionManager = new RegionManager();
        treasurer.SetNextApprover(managerAsistant);
        managerAsistant.SetNextApprover(manager);
        manager.SetNextApprover(regionManager);
        treasurer.ProcessRequest(p);

        return View();
    }
}

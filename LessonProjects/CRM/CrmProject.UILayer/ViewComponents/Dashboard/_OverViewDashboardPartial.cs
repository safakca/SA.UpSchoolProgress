using CrmProject.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrmProject.UILayer.ViewComponents.Dashboard;
public class _OverViewDashboardPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        using (var context = new Context())
        {
            ViewBag.EmployeeCount = context.Employees.Count();
            ViewBag.EmployeeWomanGenderCount = context.Users.Where(x => x.Gender == "Kadın").Count();
            ViewBag.LastUser = context.Users.OrderByDescending(x => x.Id).Take(1).SingleOrDefault().Name;
        }

        return View();
    }
}

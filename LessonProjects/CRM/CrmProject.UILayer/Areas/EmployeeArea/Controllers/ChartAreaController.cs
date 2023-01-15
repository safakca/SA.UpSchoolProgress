using CrmProject.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmProject.UILayer.Areas.EmployeeArea.Controllers;

[Area("EmployeeArea")]
public class ChartAreaController : Controller
{
    List<DepartmantSalary> departmantSalaries = new List<DepartmantSalary>();
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult DepartmantChart()
    {
        departmantSalaries.Add(new DepartmantSalary()
        {
            departmantname = "Muhasebe",
            salaryavg = 10000
        });
        departmantSalaries.Add(new DepartmantSalary()
        {
            departmantname = "IT",
            salaryavg = 30000
        });
        departmantSalaries.Add(new DepartmantSalary()
        {
            departmantname = "Satış",
            salaryavg = 20000
        });
        return Json(new { jsonList = departmantSalaries });
    }
}

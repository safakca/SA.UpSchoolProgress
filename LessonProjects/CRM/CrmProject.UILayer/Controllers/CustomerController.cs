using CrmProject.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrmProject.UILayer.Controllers;
public class CustomerController : Controller
{
    Context c = new Context();
    public IActionResult Index()
    {
        var values = c.Customers.ToList();
        return View(values);
    }
}

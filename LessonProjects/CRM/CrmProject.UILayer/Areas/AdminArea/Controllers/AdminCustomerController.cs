using CrmProject.BusinessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrmProject.UILayer.Areas.AdminArea.Controllers;

[Area("AdminArea")]
[AllowAnonymous]
public class AdminCustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public AdminCustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult CustomerList()
    {
        var jsonCustomers = JsonConvert.SerializeObject(_customerService.TGetList());
        return Json(jsonCustomers);
    }
    public IActionResult AddCustomer(Customer customer)
    {
        _customerService.TInsert(customer);
        var values = JsonConvert.SerializeObject(customer);
        return Json(values);
    }
    public IActionResult GetById(int CustomerID)
    {
        var customer = JsonConvert.SerializeObject(_customerService.TGetById(CustomerID));
        return Json(customer);
    }
    public IActionResult DeleteCustomer(int id)
    {
        var values = _customerService.TGetById(id);
        _customerService.TDelete(values);
        return Json(values);
    }
    public IActionResult UpdateCustomer(Customer customer)
    {
        _customerService.TUpdate(customer);
        var values = JsonConvert.SerializeObject(customer);
        return Json(values);
    }
}

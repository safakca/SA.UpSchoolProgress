using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_SignalR_Api2.Hubs;
using UpSchool_SignalR_Api2.Models;

namespace UpSchool_SignalR_Api2.Controllers;

[ApiController]
[Route("[controller]")]
public class DefaultController : ControllerBase
{
    private readonly ElectricService _service;

    public DefaultController(ElectricService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> SaveElectric(Electric electric)
    {
        await _service.SaveElectric(electric);
        IQueryable<Electric> electricList = _service.GetList();
        return Ok(_service.GetElectricChartList());
    }

    [HttpGet]
    public IActionResult SendData()
    {
        Random rnd = new Random();
        Enumerable.Range(1, 10).ToList().ForEach(x =>
        {
            foreach (ECity item in Enum.GetValues(typeof(ECity)))
            {
                var newElectric = new Electric
                {
                    City = item,
                    Count = rnd.Next(100, 1000),
                    ElectricDate = DateTime.Now.AddDays(x)
                };
                _service.SaveElectric(newElectric).Wait();
                System.Threading.Thread.Sleep(1000);
            }
        });
        return Ok("Elektrik verileri veri tabanına kaydedildi.");


    }
}

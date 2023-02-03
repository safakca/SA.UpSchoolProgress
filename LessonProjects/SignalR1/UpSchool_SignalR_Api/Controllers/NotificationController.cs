using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using UpSchool_SignalR_Api.Hubs;

namespace UpSchool_SignalR_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : Controller
{
    private readonly IHubContext<MyHub> _hubContext;

    public NotificationController(IHubContext<MyHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpGet("{roomCount}")]
    public async Task<IActionResult> SetRoomCount(int roomCount)
    {
        MyHub.roomCount = roomCount;
        await _hubContext.Clients.All.SendAsync("Notify", $"Bu oda en fazla {roomCount} kişi olabilir.");
        return Ok();
    }
}

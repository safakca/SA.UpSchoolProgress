using CrmProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrmProject.UILayer.Controllers;

[AllowAnonymous]
public class AnnouncementController : Controller
{
    private readonly IAnnouncementService _announcementService;
    public AnnouncementController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    public IActionResult Index()
    {
        var values = _announcementService.TGetList();
        return View(values);
    }
}

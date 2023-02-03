using Microsoft.AspNetCore.Mvc;

namespace CrmProject.UILayer.ViewComponents.Dashboard;

public class _HeadDashboardPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

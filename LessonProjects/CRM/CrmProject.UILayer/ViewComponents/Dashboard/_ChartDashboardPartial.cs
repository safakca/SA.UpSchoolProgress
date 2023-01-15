using Microsoft.AspNetCore.Mvc;

namespace CrmProject.UILayer.ViewComponents.Dashboard;
public class _ChartDashboardPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

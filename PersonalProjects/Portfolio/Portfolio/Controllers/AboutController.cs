using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.Entities;
using Portfolio.DataAccess.Repositories;

namespace Portfolio.Controllers
{
    public class AboutController : Controller
    {
        private readonly IGenericRepository<About> _aboutRepo;

        public AboutController(IGenericRepository<About> aboutRepo)
        {
            _aboutRepo = aboutRepo;
        }

        public async Task<IActionResult> About()
        {
            var response = await _aboutRepo.GetAllAsync();
            return View(response);
        }
    }
}

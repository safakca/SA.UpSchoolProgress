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
            List<About> response = await _aboutRepo.GetAllAsync();
            return View(response);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(About model)
        {
            await _aboutRepo.CreateAsync(model);
            return RedirectToAction("About");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            About result = await _aboutRepo.GetAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(About model)
        {
            await _aboutRepo.UpdateAsync(model);
            return RedirectToAction("About");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            About result = await _aboutRepo.GetAsync(id);
            return View(result);
        }
        public async Task<IActionResult> Remove(About model)
        {
            await _aboutRepo.DeleteAsync(model);
            return RedirectToAction("About");
        }
    }
}

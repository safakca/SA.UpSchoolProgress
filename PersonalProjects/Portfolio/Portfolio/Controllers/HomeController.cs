using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.Entities;
using Portfolio.DataAccess.Repositories;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Skill> _skillRepo;
        private readonly IGenericRepository<About> _aboutRepo;
         
        public HomeController(ILogger<HomeController> logger, IGenericRepository<Skill> skillRepo, IGenericRepository<About> aboutRepo)
        {
            _logger = logger;
            _skillRepo = skillRepo;
            _aboutRepo = aboutRepo;
        } 

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Skill()
        { 
            var response = await _skillRepo.GetAllAsync();
            return View(response);
        }

        public async Task<IActionResult> About()
        {
            var response = await _aboutRepo.GetAllAsync();
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
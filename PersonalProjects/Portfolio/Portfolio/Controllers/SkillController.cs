using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.Entities;
using Portfolio.DataAccess.Repositories;

namespace Portfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly IGenericRepository<Skill> _skillRepo;

        public SkillController(IGenericRepository<Skill> skillRepo)
        {
            _skillRepo = skillRepo;
        }

        public async Task<IActionResult> Skill()
        {
            List<Skill> response = await _skillRepo.GetAllAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Skill model)
        {
            await _skillRepo.CreateAsync(model);
            return RedirectToAction("Skill");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Skill result = await _skillRepo.GetAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Skill model)
        {
            await _skillRepo.UpdateAsync(model);
            return RedirectToAction("Skill");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            Skill result = await _skillRepo.GetAsync(id);
            return View(result);
        }
        public async Task<IActionResult> Remove(Skill model)
        {
            await _skillRepo.DeleteAsync(model);
            return RedirectToAction("Skill");
        }
    }
}

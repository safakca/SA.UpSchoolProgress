using Microsoft.AspNetCore.Mvc;
using SA.MongoDbCRUD.Interfaces;
using SA.MongoDbCRUD.Models;

namespace SA.MongoDbCRUD.Controllers
{
    public class MobileDeviceController : Controller
    {
        private readonly IMobileStoreService _context;

        public MobileDeviceController(IMobileStoreService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MobileDeviceEntity model)
        {
            _context.Create(model);
            return RedirectToAction("Index");
        }
    }
}

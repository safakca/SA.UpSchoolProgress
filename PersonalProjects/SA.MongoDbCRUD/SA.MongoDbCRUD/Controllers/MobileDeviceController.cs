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

        [HttpGet]
        public IActionResult Update(string Name)
        {
            MobileDeviceEntity details = _context.GetDetails(Name);
            return View(details);
        }

        [HttpPost]
        public IActionResult Update(string _id, MobileDeviceEntity model)
        {
            _context.Update(_id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string Name)
        {
            MobileDeviceEntity details = _context.GetDetails(Name);
            return View(details);
        }

        [HttpGet]
        public IActionResult Delete(string Name)
        {
            MobileDeviceEntity details = _context.GetDetails(Name);
            return View(details);
        }

        [HttpPost]
        public IActionResult DeletePost(string Name)
        {
            _context.Delete(Name);
            return RedirectToAction("Index");
        }
    }
}

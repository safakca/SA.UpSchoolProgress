using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoPortfolioProject.Models.Entities;

namespace DemoPortfolioProject.Controllers
{
    public class ServicesController : Controller
    {
       readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TBLServices.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult AddService(TBLServices p)
        {
            
            db.TBLServices.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {

            var values=db.TBLServices.Find(id);
            db.TBLServices.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UpdateService(int id)
        {
            var values = db.TBLServices.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TBLServices p)
        {
            var values = db.TBLServices.Where(x => x.ServicesID == p.ServicesID).FirstOrDefault();
            values.Title = p.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

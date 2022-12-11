using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoPortfolioProject.Models.Entities;

namespace DemoPortfolioProject.Controllers
{
    
    public class AboutController : Controller
    {
        readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();

        [Authorize]
        public ActionResult Index()
        {
            var values = db.TBLAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddAbout(TBLAbout p)
        {

            db.TBLAbout.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {

            var values = db.TBLAbout.Find(id);
            db.TBLAbout.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UpdateAbout(int? id)
        {
            var values = db.TBLAbout.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TBLAbout p)
        {
            var values = db.TBLAbout.Where(x => x.AboutID == p.AboutID).FirstOrDefault();
            values.Description = p.Description;
            values.NameSurname = p.NameSurname;
            values.İmageURL = p.İmageURL;
            values.Title = p.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
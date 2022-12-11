using DemoPortfolioProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPortfolioProject.Controllers
{
    public class ExperienceController : Controller
    {
        readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();

        public ActionResult Index()
        {

            var values = db.TBLExperience.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult AddExperience()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddExperience(TBLExperience p)
        {

            db.TBLExperience.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {

            var values = db.TBLExperience.Find(id);
            db.TBLExperience.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateExperience(int? id)
        {
            var values = db.TBLExperience.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TBLExperience p)
        {
            var values = db.TBLExperience.Where(x => x.ExperienceID == p.ExperienceID).FirstOrDefault();
            values.CompanyNamme = p.CompanyNamme;
            values.Description = p.Description;
            values.StartDate = p.StartDate;
            values.EndDate = p.EndDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
using DemoPortfolioProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPortfolioProject.Controllers
{
    public class AcademicController : Controller
    {
        readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TBLAcademic.ToList();
            return View(values);
           
        }

        [HttpGet]
        public ActionResult AddAcademic()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddAcademic(TBLAcademic p)
        {

            db.TBLAcademic.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAcademic(int id)
        {

            var values = db.TBLAcademic.Find(id);
            db.TBLAcademic.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAcademic(int? id)
        {
            var values = db.TBLAcademic.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAcademic(TBLAcademic p)
        {
            var values = db.TBLAcademic.Where(x => x.AcademicID== p.AcademicID).FirstOrDefault();
            values.SchoolName = p.SchoolName;
            values.Description = p.Description;
            values.StartDate = p.StartDate;
            values.EndDate = p.EndDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
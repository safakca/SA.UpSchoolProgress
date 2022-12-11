using DemoPortfolioProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPortfolioProject.Controllers
{
    public class UserUIController : Controller
    {
        readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeadPartial() 
        {
            return PartialView();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult DomainPartial()
        {
            return PartialView();
        }

        public PartialViewResult BannerSectionPartial()
        {
            return PartialView();
        }

        public PartialViewResult MyServicesPartial()
        {
            var values = db.TBLServices.ToList();
            return PartialView(values);
        }

        public PartialViewResult AcademicPartial()
        {
            var values = db.TBLAcademic.ToList();
            return PartialView(values);
        }

        public PartialViewResult ExperiencePartial()
        {
            var values = db.TBLExperience.ToList();
            return PartialView(values);
        }



        public PartialViewResult ReferencePartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMeassagePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SendMeassagePartial(TBLContact p)
        {
            db.TBLContact.Add(p);
            db.SaveChanges();
            return PartialView();
        }



    }
}
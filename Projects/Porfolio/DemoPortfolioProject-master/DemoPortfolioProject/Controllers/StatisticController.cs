using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoPortfolioProject.Models.Entities;

namespace DemoPortfolioProject.Controllers
{
    public class StatisticController : Controller
    {
        readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.Count = db.TBLTestomonial.Count();
            ViewBag.CountByCity = db.TBLTestomonial.Where(x => x.City == "İstanbul").Count();
            ViewBag.countExpectDevoloper= db.TBLTestomonial.Where(x => x.Profession == "YazılımMuhendisi").Count();
            ViewBag.city = db.TBLTestomonial.Where(x => x.City == "Trabzon").Select(x => x.NameSurname).FirstOrDefault();
            ViewBag.BalanceAvg = db.TBLTestomonial.Average(x => x.Balace);

            return View();
        }
    }
}
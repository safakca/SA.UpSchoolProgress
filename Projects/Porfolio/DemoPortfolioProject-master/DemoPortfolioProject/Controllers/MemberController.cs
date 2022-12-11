using DemoPortfolioProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPortfolioProject.Controllers
{
   
    public class MemberController : Controller
    {

        readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();

        public ActionResult Index()
        {
            var mail = Session["Membermail"].ToString();
            var values = db.TBLMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            ViewBag.name = values.MemberMail;
            ViewBag.surname = values.MemberSurname;
            ViewBag.ID = values.MemberID;
            

            return View();
        }
    }
}
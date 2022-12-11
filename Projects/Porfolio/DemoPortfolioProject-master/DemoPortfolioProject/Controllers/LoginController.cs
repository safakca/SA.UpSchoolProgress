using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DemoPortfolioProject.Models.Entities;

namespace DemoPortfolioProject.Controllers
{
    public class LoginController : Controller
    {
        readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TBLMember p)
        {
            var values = db.TBLMember.FirstOrDefault(x => x.MemberMail == p.MemberMail && x.MemberPassword == p.MemberPassword);
            if (values!=null)
            {
                FormsAuthentication.SetAuthCookie(values.MemberMail, false);
                Session["MemberMail"] = p.MemberMail;
                return RedirectToAction("Index", "Services");
            }
            else
            {
                return RedirectToAction("Index");
            }
        
        }

        public ActionResult CikisYap() 
        {       
            Session.Remove("MemberMail");
            return RedirectToAction("Index");
        }
    }
}
using DemoPortfolioProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();
        // GET: Message
        public ActionResult Inbox()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TBLMessage.Where(x => x.ReceiverMail == mail).ToList();
            return View(values);
        }

        public ActionResult Outbox()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TBLMessage.Where(x => x.SenderMail == mail).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult SendMesseage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMesseage(TBLMessage p)
        {
            var mail = Session["MemberMail"].ToString();
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.SenderMail = mail;
            p.SenderNameSurname = db.TBLMember.Where(x => x.MemberMail == mail).Select(x => x.MemberName + " " + x.MemberSurname).FirstOrDefault();
            p.ReceiverNameSurname=db.TBLMember.Where(x=>x.MemberMail==p.ReceiverMail).Select(x => x.MemberName + " " + x.MemberSurname).FirstOrDefault();
       
            db.TBLMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Outbox");
        }

        public ActionResult MesseageDetails(int id)
        {
            var okunacakMesaj = db.TBLMessage.Where(x => x.MessageID == id).Select(x => x.MessageContent).FirstOrDefault();
            ViewBag.mesaj = okunacakMesaj;
            return View();
        }
    }
}
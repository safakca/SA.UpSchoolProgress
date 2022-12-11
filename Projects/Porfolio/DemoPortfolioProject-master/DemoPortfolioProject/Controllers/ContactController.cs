using DemoPortfolioProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        readonly DbDemoPortfolioEntities db = new DbDemoPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TBLContact.ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var values = db.TBLContact.Find(id);
            db.TBLContact.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ContactMesajGonder(int id)
        {
            var values = db.TBLContact.Find(id);      
            return View(values);
        }

        [HttpPost]
        public ActionResult ContactMesajGonder(TBLContact p)
        {
            var values = db.TBLContact.Find(p.ContactID);            
            values.Email=p.Email;
            values.MessageSubject = p.MessageSubject;    
            values.NameSurname = p.NameSurname;
            values.Message = p.Message;
            db.TBLContact.Add(p); 
            db.SaveChanges();     
            return RedirectToAction("Index");
        }

        public ActionResult ContactDetails(int id) 
        {
            var mesaj = db.TBLContact.Where(x => x.ContactID == id).Select(x => x.Message).FirstOrDefault();
            ViewBag.mesaj = mesaj;
            return View();
        }

    }
}
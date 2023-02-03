using CrmProject.BusinessLayer.Abstract;
using CrmProject.DTOLayer.DTOs.ContactDTOs;
using CrmProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrmProject.UILayer.Areas.AdminArea.Controllers;

[Area("AdminArea")]
[AllowAnonymous]

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
    [HttpGet]
    public IActionResult AddContact()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddContact(ContactAddDTO model)
    {
        if (ModelState.IsValid)
        {
            _contactService.TInsert(new Contact()
            {
                Name = model.Name,
                Mail = model.Mail,
                Content = model.Content,
                Subject = model.Subject,
                Date = DateTime.Parse(DateTime.Now.ToShortDateString())
            });
            return RedirectToAction("Index");
        }
        return View();
    }
}

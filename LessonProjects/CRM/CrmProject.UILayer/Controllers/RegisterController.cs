using CrmProject.EntityLayer.Concrete;
using CrmProject.UILayer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace CrmProject.UILayer.Controllers;
[AllowAnonymous]
public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(UserSıgnUpModel p)
    {
        if (ModelState.IsValid)
        {
            AppUser appUser = new AppUser()
            {
                UserName = p.UserName,
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                MailCode = new Random().Next(10000, 999999).ToString()
            };
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    SendEmail(appUser.Email, appUser.MailCode);
                    return RedirectToAction("EmailConfirmed", "Register");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifreler uyuşmuyor.");
            }
        }
        return View();
    }
    [HttpGet]
    public IActionResult EmailConfirmed()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> EmailConfirmed(AppUser appUser)
    {
        var user = await _userManager.FindByEmailAsync(appUser.Email);
        if (user.MailCode == appUser.MailCode)
        {
            user.EmailConfirmed = true;

            var result = await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Login");
        }
        return View();
    }
    public void SendEmail(string email, string emailcode)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "xx@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", email);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = emailcode;
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject = "Üyelik Kaydı";

        SmtpClient smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, false);
        smtp.Authenticate("xx@gmail.com", "ovdzzruhpkjokckm");
        smtp.Send(mimeMessage);
        smtp.Disconnect(true);
    }


}

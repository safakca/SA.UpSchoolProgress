using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Concrete;
using CrmProject.EntityLayer.Concrete;
using CrmProject.UILayer.Areas.EmployeeArea.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrmProject.UILayer.Areas.EmployeeArea.Controllers;

[Area("EmployeeArea")]
public class MessageAreaController : Controller
{
    private readonly IMessageService _messageService;
    private readonly UserManager<AppUser> _userManager;

    public MessageAreaController(IMessageService messageService, UserManager<AppUser> userManager)
    {
        _messageService = messageService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> SendMessage()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SendMessage(Message message)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        message.SenderEmail = user.Email;
        message.SenderName = user.Name + " " + user.Surname;
        using (var context = new Context())
        {
            message.RecieverName = context.Users.Where(x => x.Email == message.RecieverEmail).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
        }
        _messageService.TInsert(message);

        MailRequest mailRequest = new MailRequest();
        mailRequest.EmailContent = message.MessageContent;
        mailRequest.EmailSubject = message.MessageSubject;
        mailRequest.ReceiverMail = message.RecieverEmail;

        SendEmail(mailRequest);

        return RedirectToAction("SendMessage");
    }
    [HttpGet]
    public async Task<IActionResult> SendEmail()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SendEmail(MailRequest mailRequest)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressfrom = new MailboxAddress("Admin", "xx@gmail.com");
        mimeMessage.From.Add(mailboxAddressfrom);

        MailboxAddress mailboxAddressto = new MailboxAddress("User", mailRequest.ReceiverMail);
        mimeMessage.To.Add(mailboxAddressto);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = mailRequest.EmailContent;

        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject = mailRequest.EmailSubject;

        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("xx@gmail.com", "ovdzzruhpkjokckm");
        client.Send(mimeMessage);
        client.Disconnect(true);

        return View();
    }
}

using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using UpSchool_Observer_DesignPattern.DAL;

namespace UpSchool_Observer_DesignPattern.ObserverDesignPattern;
public class UserObserverSendMail : IUserObserver
{
    private readonly IServiceProvider _serviceProvider;
    public UserObserverSendMail(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void CreateUser(AppUser appUser)
    {
        var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendMail>>(); 
        MimeMessage mimeMessage = new MimeMessage();
        MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin Observer", "gönderen mail");
        MailboxAddress mailboxAddress = new MailboxAddress("User", appUser.Email);
        mimeMessage.To.Add(mailboxAddress);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = "Observer Design Pattern Dersimizde Bu Adıma Gelebildiğiniz İçin Size İndirim Kodu Tanımladık, Kodunuz GIFT0001";
        mimeMessage.Body = bodyBuilder.ToMessageBody();
        mimeMessage.Subject = "Hoş Geldin İndirim Hediyesi";

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Connect("smtp.gmail.com", 587, false);
        smtpClient.Authenticate("gönderen mail", "mail key");
        smtpClient.Send(mimeMessage);
        smtpClient.Disconnect(true);
        logger.LogInformation($"{appUser.Name + " " + appUser.Surname} isimli kullanıcının {appUser.Email} adlı mail adresine indirim kodu maili başarıyla gönderildi."); 
    }
}

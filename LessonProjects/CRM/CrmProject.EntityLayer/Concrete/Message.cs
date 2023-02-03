using System;

namespace CrmProject.EntityLayer.Concrete;
public class Message
{
    public int MessageID { get; set; }
    public string MessageSubject { get; set; }
    public string MessageContent { get; set; }
    public string RecieverName { get; set; }
    public string RecieverEmail { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public DateTime Date { get; set; }
}

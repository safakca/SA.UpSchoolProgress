using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CrmProject.EntityLayer.Concrete;
public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ImageURL { get; set; }
    public string Gender { get; set; }
    public List<EmployeeTask> EmployeeTask { get; set; }
    public List<EmployeeTask> AssigneeEmployeeTask { get; set; }
    public string MailCode { get; set; }
}

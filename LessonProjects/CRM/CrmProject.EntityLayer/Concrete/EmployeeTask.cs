using System;
using System.Collections.Generic;

namespace CrmProject.EntityLayer.Concrete;
public class EmployeeTask
{
    public int EmployeeTaskID { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public int AssigneeUserId { get; set; }
    public AppUser AppAssigneeUser { get; set; }
    public List<EmployeeTaskDetail> EmployeeTaskDetail { get; set; }
}

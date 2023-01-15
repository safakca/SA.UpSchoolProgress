using System;

namespace CrmProject.EntityLayer.Concrete;
public class EmployeeTaskDetail
{
    public int EmployeeTaskDetailId { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int EmployeeTaskId { get; set; }
    public EmployeeTask EmployeeTask { get; set; }
}

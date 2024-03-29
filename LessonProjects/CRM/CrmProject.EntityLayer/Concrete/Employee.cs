﻿using System.ComponentModel.DataAnnotations;

namespace CrmProject.EntityLayer.Concrete;
public class Employee
{
    [Key]
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeSurname { get; set; }
    public string EmployeeMail { get; set; }
    public string EmployeeImage { get; set; }
    public int CategoryID { get; set; }
    public Category Category { get; set; }
    public bool EmployeeStatus { get; set; }

}

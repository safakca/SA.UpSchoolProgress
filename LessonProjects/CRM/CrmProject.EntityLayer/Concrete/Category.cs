using System.Collections.Generic;

namespace CrmProject.EntityLayer.Concrete;
public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public ICollection<Employee> Employees { get; set; }
}

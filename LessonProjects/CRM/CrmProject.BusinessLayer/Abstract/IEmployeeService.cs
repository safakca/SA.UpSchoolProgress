using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Abstract;
public interface IEmployeeService : IGenericService<Employee>
{
    public List<Employee> TGetEmployeesByCategory();
    void TChangeEmployeeStatusToTrue(int id);
    void TChangeEmployeeStatusToFalse(int id);
}

using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.DataAccessLayer.Abstract;
public interface IEmployeeDal : IGenericDal<Employee>
{
    List<Employee> GetEmployeesByCategory();
    void ChangeEmployeeStatusToTrue(int id);
    void ChangeEmployeeStatusToFalse(int id);
}

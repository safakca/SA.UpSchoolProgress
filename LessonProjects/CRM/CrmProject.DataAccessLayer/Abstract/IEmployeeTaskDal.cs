using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.DataAccessLayer.Abstract;
public interface IEmployeeTaskDal : IGenericDal<EmployeeTask>
{
    List<EmployeeTask> GetEmployeeTasksByEmployee();
    List<EmployeeTask> GetEmployeeTasksByEmployeeAndAssigneeUser();
    List<EmployeeTask> GetEmployeeTasksByUserId(int id);
}

using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Abstract;
public interface IEmployeeTaskService : IGenericService<EmployeeTask>
{
    List<EmployeeTask> TGetEmployeeTasksByEmployee();
    List<EmployeeTask> TGetEmployeeTasksByEmployeeAndAssigneeUser();
    List<EmployeeTask> TGetEmployeeTasksByUserId(int id);
}

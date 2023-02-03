using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Abstract;
public interface IEmployeeTaskDetailService : IGenericService<EmployeeTaskDetail>
{
    List<EmployeeTaskDetail> TGetEmployeeTaskDetailGetByID(int id);
}

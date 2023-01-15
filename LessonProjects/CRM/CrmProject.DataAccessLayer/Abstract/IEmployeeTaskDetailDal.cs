using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.DataAccessLayer.Abstract;
public interface IEmployeeTaskDetailDal : IGenericDal<EmployeeTaskDetail>
{
    List<EmployeeTaskDetail> GetEmployeeTaskDetailGetByID(int id);
}

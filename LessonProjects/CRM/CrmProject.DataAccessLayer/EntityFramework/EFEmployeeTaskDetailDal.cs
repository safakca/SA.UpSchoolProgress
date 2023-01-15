using CrmProject.DataAccessLayer.Abstract;
using CrmProject.DataAccessLayer.Concrete;
using CrmProject.DataAccessLayer.Repository;
using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace CrmProject.DataAccessLayer.EntityFramework;
public class EFEmployeeTaskDetailDal : GenericRepository<EmployeeTaskDetail>, IEmployeeTaskDetailDal
{
    public List<EmployeeTaskDetail> GetEmployeeTaskDetailGetByID(int id)
    {
        using (var context = new Context())
        {
            return context.EmployeeTaskDetails.Where(x => x.EmployeeTaskId == id).ToList();
        }
    }
}

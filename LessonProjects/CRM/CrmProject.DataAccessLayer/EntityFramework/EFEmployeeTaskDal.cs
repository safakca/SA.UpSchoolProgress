using CrmProject.DataAccessLayer.Abstract;
using CrmProject.DataAccessLayer.Concrete;
using CrmProject.DataAccessLayer.Repository;
using CrmProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CrmProject.DataAccessLayer.EntityFramework;
public class EFEmployeeTaskDal : GenericRepository<EmployeeTask>, IEmployeeTaskDal
{
    public List<EmployeeTask> GetEmployeeTasksByEmployee()
    {
        using (var context = new Context())
        {
            var values = context.EmployeeTasks.Include(x => x.AppUser).ToList();
            return values;
        }
    }

    public List<EmployeeTask> GetEmployeeTasksByEmployeeAndAssigneeUser()
    {
        using (var context = new Context())
        {
            var values = context.EmployeeTasks.Include(x => x.AppUser).Include(x => x.AppAssigneeUser).ToList();
            return values;
        }
    }

    public List<EmployeeTask> GetEmployeeTasksByUserId(int id)
    {
        using (var context = new Context())
        {
            var values = context.EmployeeTasks.Where(x => x.AppUserId == id).ToList();
            return values;
        }
    }
}

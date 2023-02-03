using CrmProject.DataAccessLayer.Abstract;
using CrmProject.DataAccessLayer.Concrete;
using CrmProject.DataAccessLayer.Repository;
using CrmProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CrmProject.DataAccessLayer.EntityFramework;
public class EFEmployeeDal : GenericRepository<Employee>, IEmployeeDal
{
    private readonly Context _context;

    public EFEmployeeDal(Context context)
    {
        _context = context;
    }

    public void ChangeEmployeeStatusToFalse(int id)
    {
        var values = _context.Employees.Find(id);
        values.EmployeeStatus = false;
        _context.SaveChanges();
    }

    public void ChangeEmployeeStatusToTrue(int id)
    {
        var values = _context.Employees.Find(id);
        values.EmployeeStatus = true;
        _context.SaveChanges();
    }

    public List<Employee> GetEmployeesByCategory()
    {
        return _context.Employees.Include(x => x.Category).ToList();
    }
}

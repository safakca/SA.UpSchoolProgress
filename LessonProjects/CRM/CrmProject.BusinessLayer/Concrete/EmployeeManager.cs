using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class EmployeeManager : IEmployeeService
{
    IEmployeeDal _employeeDal;

    public EmployeeManager(IEmployeeDal employeeDal)
    {
        _employeeDal = employeeDal;
    }

    public void TChangeEmployeeStatusToFalse(int id)
    {
        _employeeDal.ChangeEmployeeStatusToFalse(id);
    }

    public void TChangeEmployeeStatusToTrue(int id)
    {
        _employeeDal.ChangeEmployeeStatusToTrue(id);
    }

    public void TDelete(Employee t)
    {
        _employeeDal.Delete(t);
    }

    public Employee TGetById(int id)
    {
        return _employeeDal.GetById(id);
    }

    public List<Employee> TGetEmployeesByCategory()
    {
        return _employeeDal.GetEmployeesByCategory();
    }

    public List<Employee> TGetList()
    {
        return _employeeDal.GetList();
    }

    public void TInsert(Employee t)
    {
        _employeeDal.Insert(t);
    }

    public void TUpdate(Employee t)
    {
        _employeeDal.Update(t);
    }
}

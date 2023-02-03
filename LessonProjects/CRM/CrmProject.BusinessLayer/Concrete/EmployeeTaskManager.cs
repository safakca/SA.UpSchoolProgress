using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class EmployeeTaskManager : IEmployeeTaskService
{
    IEmployeeTaskDal _employeeTask;

    public EmployeeTaskManager(IEmployeeTaskDal employeeTask)
    {
        _employeeTask = employeeTask;
    }

    public void TDelete(EmployeeTask t)
    {
        throw new NotImplementedException();
    }

    public EmployeeTask TGetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<EmployeeTask> TGetEmployeeTasksByEmployee()
    {
        return _employeeTask.GetEmployeeTasksByEmployee();
    }

    public List<EmployeeTask> TGetEmployeeTasksByEmployeeAndAssigneeUser()
    {
        return _employeeTask.GetEmployeeTasksByEmployeeAndAssigneeUser();
    }

    public List<EmployeeTask> TGetEmployeeTasksByUserId(int id)
    {
        return _employeeTask.GetEmployeeTasksByUserId(id);
    }

    public List<EmployeeTask> TGetList()
    {
        throw new NotImplementedException();
    }

    public void TInsert(EmployeeTask t)
    {
        _employeeTask.Insert(t);
    }

    public void TUpdate(EmployeeTask t)
    {
        throw new NotImplementedException();
    }
}

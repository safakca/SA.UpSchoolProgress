using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class EmployeeTaskDetailManager : IEmployeeTaskDetailService
{
    private readonly IEmployeeTaskDetailDal _employeeTaskDetailDal;

    public EmployeeTaskDetailManager(IEmployeeTaskDetailDal employeeTaskDetailDal)
    {
        _employeeTaskDetailDal = employeeTaskDetailDal;
    }

    public void TDelete(EmployeeTaskDetail t)
    {
        throw new NotImplementedException();
    }

    public EmployeeTaskDetail TGetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<EmployeeTaskDetail> TGetEmployeeTaskDetailGetByID(int id)
    {
        return _employeeTaskDetailDal.GetEmployeeTaskDetailGetByID(id);
    }

    public List<EmployeeTaskDetail> TGetList()
    {
        throw new NotImplementedException();
    }

    public void TInsert(EmployeeTaskDetail t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(EmployeeTaskDetail t)
    {
        throw new NotImplementedException();
    }
}

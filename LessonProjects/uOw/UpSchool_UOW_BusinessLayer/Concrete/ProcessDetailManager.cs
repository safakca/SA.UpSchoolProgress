using System;
using System.Collections.Generic;
using UpSchool_UOW_BusinessLayer.Abstract;
using UpSchool_UOW_DataAccessLayer.Abstract;
using UpSchool_UOW_DataAccessLayer.UnitOfWork;
using UpSchool_UOW_EntityLayer;

namespace UpSchool_UOW_BusinessLayer.Concrete;
public class ProcessDetailManager : IProcessDetailService
{
    private readonly IProcessDetailDal _detailDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;

    public ProcessDetailManager(IProcessDetailDal detailDal, IUnitOfWorkDal unitOfWorkDal)
    {
        _detailDal = detailDal;
        _unitOfWorkDal = unitOfWorkDal;
    }

    public void TDelete(ProcessDetail t)
    {
        throw new NotImplementedException();
    }

    public ProcessDetail TGetByID(int id)
    {
        throw new NotImplementedException();
    }

    public List<ProcessDetail> TGetList()
    {
        throw new NotImplementedException();
    }

    public void TInsert(ProcessDetail t)
    {
        _detailDal.Insert(t);
        _unitOfWorkDal.Save();
    }

    public void TMultiUpdate(List<ProcessDetail> t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(ProcessDetail t)
    {
        throw new NotImplementedException();
    }

    public void TUpdateBalance(List<Account> account)
    {
        throw new NotImplementedException();
    }
}

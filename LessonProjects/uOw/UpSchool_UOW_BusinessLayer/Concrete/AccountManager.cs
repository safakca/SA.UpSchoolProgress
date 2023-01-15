using System.Collections.Generic;
using UpSchool_UOW_BusinessLayer.Abstract;
using UpSchool_UOW_DataAccessLayer.Abstract;
using UpSchool_UOW_DataAccessLayer.UnitOfWork;
using UpSchool_UOW_EntityLayer;

namespace UpSchool_UOW_BusinessLayer.Concrete;
public class AccountManager : IAccountService
{
    private readonly IAccountDal _accountDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;

    public AccountManager(IAccountDal accountDal, IUnitOfWorkDal unitOfWorkDal)
    {
        _accountDal = accountDal;
        _unitOfWorkDal = unitOfWorkDal;
    }

    public void TDelete(Account t)
    {
        _accountDal.Delete(t); 
        _unitOfWorkDal.Save(); 
    }

    public Account TGetByID(int id)
    {
        return _accountDal.GetByID(id);
    }

    public List<Account> TGetList()
    {
        return _accountDal.GetList();
    }

    public void TInsert(Account t)
    {
        _accountDal.Insert(t);
        _unitOfWorkDal.Save();
    }

    public void TMultiUpdate(List<Account> t)
    {
        for (int i = 0; i < t.Count; i++)
        {
            if (t[i].AccountBalance > 0)
            {
                _accountDal.MultiUpdate(t);
                _unitOfWorkDal.Save(); 
            }
        } 
    }

    public void TUpdate(Account t)
    {
        _accountDal.Update(t);
        _unitOfWorkDal.Save();
    }
}

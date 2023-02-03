using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class SupplierManager : ISupplierService
{
    ISupplierDal _supplierDal;

    public SupplierManager(ISupplierDal supplierDal)
    {
        _supplierDal = supplierDal;
    }

    public void TDelete(Supplier t)
    {
        _supplierDal.Delete(t);
    }

    public Supplier TGetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Supplier> TGetList()
    {
        return _supplierDal.GetList();
    }

    public void TInsert(Supplier t)
    {
        _supplierDal.Insert(t);
    }

    public void TUpdate(Supplier t)
    {
        _supplierDal.Update(t);
    }
}

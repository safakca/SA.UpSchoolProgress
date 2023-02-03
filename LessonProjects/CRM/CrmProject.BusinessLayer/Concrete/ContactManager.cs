using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class ContactManager : IContactService
{
    IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void TDelete(Contact t)
    {
        _contactDal.Delete(t);
    }

    public Contact TGetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Contact> TGetList()
    {
        return _contactDal.GetList();
    }

    public void TInsert(Contact t)
    {
        _contactDal.Insert(t);
    }

    public void TUpdate(Contact t)
    {
        _contactDal.Update(t);
    }
}

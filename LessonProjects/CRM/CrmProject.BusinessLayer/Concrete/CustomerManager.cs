﻿using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class CustomerManager : ICustomerService
{
    ICustomerDal _customerDal;
    public CustomerManager(ICustomerDal customer)
    {
        _customerDal = customer;
    }

    public void TDelete(Customer t)
    {
        _customerDal.Delete(t);
    }

    public Customer TGetById(int id)
    {
        return _customerDal.GetById(id);
    }

    public List<Customer> TGetList()
    {
        return _customerDal.GetList();
    }

    public void TInsert(Customer t)
    {
        _customerDal.Insert(t);
    }

    public void TUpdate(Customer t)
    {
        _customerDal.Update(t);
    }
}

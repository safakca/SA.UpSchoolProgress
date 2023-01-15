using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class MessageManager : IMessageService
{
    IMessageDal _messageDal;

    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }

    public void TDelete(Message t)
    {
        throw new NotImplementedException();
    }

    public Message TGetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Message> TGetList()
    {
        throw new NotImplementedException();
    }

    public void TInsert(Message t)
    {
        _messageDal.Insert(t);
    }

    public void TUpdate(Message t)
    {
        throw new NotImplementedException();
    }
}

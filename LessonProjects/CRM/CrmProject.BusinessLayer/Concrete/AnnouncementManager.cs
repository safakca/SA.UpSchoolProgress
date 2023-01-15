using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class AnnouncementManager : IAnnouncementService
{
    private readonly IAnnouncementDal _announcementDal;

    public AnnouncementManager(IAnnouncementDal announcementDal)
    {
        _announcementDal = announcementDal;
    }

    public List<Announcement> TContainA()
    {
        return _announcementDal.ContainA();
    }

    public void TDelete(Announcement t)
    {
        _announcementDal.Delete(t);
    }

    public Announcement TGetById(int id)
    {
        return _announcementDal.GetById(id);
    }

    public List<Announcement> TGetList()
    {
        return _announcementDal.GetList();
    }

    public void TInsert(Announcement t)
    {
        _announcementDal.Insert(t);
    }

    public void TUpdate(Announcement t)
    {
        _announcementDal.Update(t);
    }
}

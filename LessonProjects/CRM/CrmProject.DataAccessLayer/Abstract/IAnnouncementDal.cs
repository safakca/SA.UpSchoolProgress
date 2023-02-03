using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.DataAccessLayer.Abstract;
public interface IAnnouncementDal : IGenericDal<Announcement>
{
    public List<Announcement> ContainA();
}

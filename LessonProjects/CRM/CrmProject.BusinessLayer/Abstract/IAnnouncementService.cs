using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Abstract;
public interface IAnnouncementService : IGenericService<Announcement>
{
    public List<Announcement> TContainA();
}

using CrmProject.DataAccessLayer.Abstract;
using CrmProject.DataAccessLayer.Concrete;
using CrmProject.DataAccessLayer.Repository;
using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace CrmProject.DataAccessLayer.EntityFramework;
public class EFAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
{
    public List<Announcement> ContainA()
    {
        using (var context = new Context())
        {
            var values = context.Announcements.Where(x => x.Title.Contains("a")).ToList();
            return values;
        }
    }
}

using UpSchool_UOW_DataAccessLayer.Abstract;
using UpSchool_UOW_DataAccessLayer.Concrete;
using UpSchool_UOW_DataAccessLayer.Repository;
using UpSchool_UOW_EntityLayer;

namespace UpSchool_UOW_DataAccessLayer.EntityFramework;
public class EfAccountDal : GenericRepository<Account>, IAccountDal
{
    public EfAccountDal(Context context) : base(context) { }
}

using System;
using UpSchool_UOW_DataAccessLayer.Abstract;
using UpSchool_UOW_DataAccessLayer.Concrete;
using UpSchool_UOW_DataAccessLayer.Repository;
using UpSchool_UOW_EntityLayer;

namespace UpSchool_UOW_DataAccessLayer.EntityFramework;
public class EfProcessDetailDal : GenericRepository<ProcessDetail>, IProcessDetailDal
{ 
    private IServiceProvider _serviceProvider;
     
    public EfProcessDetailDal(Context context, IServiceProvider serviceProvider) : base(context)
    {
        _serviceProvider = serviceProvider;
    }  
}

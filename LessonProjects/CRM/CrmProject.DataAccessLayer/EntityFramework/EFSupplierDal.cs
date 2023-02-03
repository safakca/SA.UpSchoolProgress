using CrmProject.DataAccessLayer.Abstract;
using CrmProject.DataAccessLayer.Repository;
using CrmProject.EntityLayer.Concrete;

namespace CrmProject.DataAccessLayer.EntityFramework;
public class EFSupplierDal : GenericRepository<Supplier>, ISupplierDal { }

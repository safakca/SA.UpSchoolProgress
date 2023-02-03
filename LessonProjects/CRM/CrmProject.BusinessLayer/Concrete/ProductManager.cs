using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class ProductManager : IProductService
{
    IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    public void TDelete(Product t)
    {
        _productDal.Delete(t);
    }

    public Product TGetById(int id)
    {
        return _productDal.GetById(id);
    }

    public List<Product> TGetList()
    {
        return _productDal.GetList();
    }

    public void TInsert(Product t)
    {
        _productDal.Insert(t);
    }

    public void TUpdate(Product t)
    {
        _productDal.Update(t);
    }
}

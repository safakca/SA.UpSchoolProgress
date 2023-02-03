using CrmProject.BusinessLayer.Abstract;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmProject.BusinessLayer.Concrete;
public class CategoryManager : ICategoryService
{
    ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public void TDelete(Category t)
    {
        _categoryDal.Delete(t);
    }

    public Category TGetById(int id)
    {
        return _categoryDal.GetById(id);
    }

    public List<Category> TGetList()
    {
        return _categoryDal.GetList();
    }

    public void TInsert(Category t)
    {
        _categoryDal.Insert(t);
    }

    public void TUpdate(Category t)
    {
        _categoryDal.Update(t);
    }
}

﻿using System.Collections.Generic;

namespace CrmProject.DataAccessLayer.Abstract;
public interface IGenericDal<T>
{
    void Insert(T t);
    void Delete(T t);
    void Update(T t);
    List<T> GetList();
    T GetById(int id);
}

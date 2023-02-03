using System.Collections.Generic;

namespace UpSchool_UOW_BusinessLayer.Abstract;
public interface IGenericService<T>
{
    void TInsert(T t);
    void TDelete(T t);
    void TUpdate(T t);
    List<T> TGetList();
    T TGetByID(int id);
    void TMultiUpdate(List<T> t);
}

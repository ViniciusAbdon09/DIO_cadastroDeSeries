using System.Collections.Generic;
namespace Series.interfaces
{
    public interface IRepository<T>
    {
        List<T> Lista();
         T getId(int id);
         void insert(T entidade);
         void Delete(int id);
         void Update(int id, T entidade);
         int nextId();
    }
}
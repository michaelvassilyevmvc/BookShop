using System.Collections.Generic;

namespace BookShop.Repo
{
    public interface IRepositoryBase<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

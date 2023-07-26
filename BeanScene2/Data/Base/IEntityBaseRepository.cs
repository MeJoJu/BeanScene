using BeanScene2.Models;
using System.Linq.Expressions;

namespace BeanScene2.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        //there are 5 methods: GetAll(), GetById(int id), Add(Area NewArea), Update(int id, Area NewArea), Delete(int id)
        Task<IEnumerable<T>> GetAllAsync();
        //Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(int id);
        //Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);
        //id is for get the element, Area NewArea is for change the old object Area
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}

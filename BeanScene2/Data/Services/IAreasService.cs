using BeanScene2.Models;

namespace BeanScene2.Data.Services
{
    public interface IAreasService
    {
        //there are 5 methods: GetAll(), GetById(int id), Add(Area NewArea), Update(int id, Area NewArea), Delete(int id)
        Task<IEnumerable<Area>> GetAllAsync();
        Task<Area> GetByIdAsync(int id);
        Task AddAsync(Area NewArea);
        //id is for get the element, Area NewArea is for change the old object Area
        Task<Area> UpdateAsync(int id, Area NewArea);
        Task DeleteAsync(int id);
    }
}

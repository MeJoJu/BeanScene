using BeanScene2.Models;
using Microsoft.EntityFrameworkCore;

namespace BeanScene2.Data.Services
{
    public class AreasService : IAreasService
    {
        private readonly BeanScene2Context _context;

        public AreasService(BeanScene2Context context)
        {
            _context = context;
        }

        public Task AddAsync(Area NewArea)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            var result = await _context.Area.ToListAsync();
            return result;
        }

        public Task<Area> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Area> UpdateAsync(int id, Area NewArea)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task AddAsync(Area NewArea)
        {
            await _context.Area.AddAsync(NewArea);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var result = await _context.Area.FirstOrDefaultAsync(n=>n.AreaId == id);
            _context.Area.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            var result = await _context.Area.ToListAsync();
            return result;
        }

        public async Task<Area> GetByIdAsync(int id)
        {
            var result = _context.Area.FirstOrDefault(n => n.AreaId == id);
            return result;
        }

        public async Task<Area> UpdateAsync(int id, Area NewArea)
        {
            _context.Update(NewArea);
            await _context.SaveChangesAsync();
            return NewArea;
        }
    }
}

using SessiaApi.Interfaces;
using SessiaApi.Model;
using SessiaApi.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace SessiaApi.Services
{
    public class PartService : IPartService
    {
        private readonly SessiaCarServiceContext _context;
        public PartService(SessiaCarServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Part>> GetAllAsync() => await _context.Parts.ToListAsync();
        public async Task<Part> GetByIdAsync(int id) => await _context.Parts.FirstOrDefaultAsync(p => p.Id == id);
        public async Task<Part> CreateAsync(Part part)
        {
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();
            return part;
        }
        public async Task<bool> UpdateAsync(Part part)
        {
            _context.Entry(part).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part == null) return false;
            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 
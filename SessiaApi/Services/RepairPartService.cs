using SessiaApi.Interfaces;
using SessiaApi.Model;
using SessiaApi.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace SessiaApi.Services
{
    public class RepairPartService : IRepairPartService
    {
        private readonly SessiaCarServiceContext _context;
        public RepairPartService(SessiaCarServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RepairPart>> GetAllAsync() => await _context.RepairParts.Include(rp => rp.RepairRequest).Include(rp => rp.Part).ToListAsync();
        public async Task<RepairPart> GetByIdAsync(int id) => await _context.RepairParts.Include(rp => rp.RepairRequest).Include(rp => rp.Part).FirstOrDefaultAsync(rp => rp.Id == id);
        public async Task<RepairPart> CreateAsync(RepairPart repairPart)
        {
            _context.RepairParts.Add(repairPart);
            await _context.SaveChangesAsync();
            return repairPart;
        }
        public async Task<bool> UpdateAsync(RepairPart repairPart)
        {
            _context.Entry(repairPart).State = EntityState.Modified;
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
            var repairPart = await _context.RepairParts.FindAsync(id);
            if (repairPart == null) return false;
            _context.RepairParts.Remove(repairPart);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 
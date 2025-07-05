using SessiaApi.Interfaces;
using SessiaApi.Model;
using SessiaApi.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace SessiaApi.Services
{
    public class RepairRequestService : IRepairRequestService
    {
        private readonly SessiaCarServiceContext _context;
        public RepairRequestService(SessiaCarServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RepairRequest>> GetAllAsync() => await _context.RepairRequests.Include(r => r.Car).Include(r => r.Client).Include(r => r.Manager).Include(r => r.Master).ToListAsync();
        public async Task<RepairRequest> GetByIdAsync(int id) => await _context.RepairRequests.Include(r => r.Car).Include(r => r.Client).Include(r => r.Manager).Include(r => r.Master).FirstOrDefaultAsync(r => r.Id == id);
        public async Task<RepairRequest> CreateAsync(RepairRequest request)
        {
            request.CreatedAt = DateTime.Now;
            _context.RepairRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<bool> UpdateAsync(RepairRequest request)
        {
            _context.Entry(request).State = EntityState.Modified;
            request.UpdatedAt = DateTime.Now;
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
            var request = await _context.RepairRequests.FindAsync(id);
            if (request == null) return false;
            _context.RepairRequests.Remove(request);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 
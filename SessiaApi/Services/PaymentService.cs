using SessiaApi.Interfaces;
using SessiaApi.Model;
using SessiaApi.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace SessiaApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly SessiaCarServiceContext _context;
        public PaymentService(SessiaCarServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync() => await _context.Payments.Include(p => p.RepairRequest).ToListAsync();
        public async Task<Payment> GetByIdAsync(int id) => await _context.Payments.Include(p => p.RepairRequest).FirstOrDefaultAsync(p => p.Id == id);
        public async Task<Payment> CreateAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
        public async Task<bool> UpdateAsync(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
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
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return false;
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 
using SessiaApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SessiaApi.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        Task<Payment> CreateAsync(Payment payment);
        Task<bool> UpdateAsync(Payment payment);
        Task<bool> DeleteAsync(int id);
    }
} 
using SessiaApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SessiaApi.Interfaces
{
    public interface IRepairRequestService
    {
        Task<IEnumerable<RepairRequest>> GetAllAsync();
        Task<RepairRequest> GetByIdAsync(int id);
        Task<RepairRequest> CreateAsync(RepairRequest request);
        Task<bool> UpdateAsync(RepairRequest request);
        Task<bool> DeleteAsync(int id);
    }
} 
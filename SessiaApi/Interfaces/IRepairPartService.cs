using SessiaApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SessiaApi.Interfaces
{
    public interface IRepairPartService
    {
        Task<IEnumerable<RepairPart>> GetAllAsync();
        Task<RepairPart> GetByIdAsync(int id);
        Task<RepairPart> CreateAsync(RepairPart repairPart);
        Task<bool> UpdateAsync(RepairPart repairPart);
        Task<bool> DeleteAsync(int id);
    }
} 
using SessiaApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SessiaApi.Interfaces
{
    public interface IPartService
    {
        Task<IEnumerable<Part>> GetAllAsync();
        Task<Part> GetByIdAsync(int id);
        Task<Part> CreateAsync(Part part);
        Task<bool> UpdateAsync(Part part);
        Task<bool> DeleteAsync(int id);
    }
} 
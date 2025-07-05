using SessiaApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SessiaApi.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<bool> DeleteAsync(int id);
    }
} 
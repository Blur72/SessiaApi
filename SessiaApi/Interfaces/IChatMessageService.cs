using SessiaApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SessiaApi.Interfaces
{
    public interface IChatMessageService
    {
        Task<IEnumerable<ChatMessage>> GetAllAsync();
        Task<ChatMessage> GetByIdAsync(int id);
        Task<ChatMessage> CreateAsync(ChatMessage message);
        Task<bool> DeleteAsync(int id);
    }
} 
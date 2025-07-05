using SessiaApi.Interfaces;
using SessiaApi.Model;
using SessiaApi.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace SessiaApi.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly SessiaCarServiceContext _context;
        public ChatMessageService(SessiaCarServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChatMessage>> GetAllAsync() => await _context.ChatMessages.Include(m => m.RepairRequest).Include(m => m.Sender).ToListAsync();
        public async Task<ChatMessage> GetByIdAsync(int id) => await _context.ChatMessages.Include(m => m.RepairRequest).Include(m => m.Sender).FirstOrDefaultAsync(m => m.Id == id);
        public async Task<ChatMessage> CreateAsync(ChatMessage message)
        {
            message.SentAt = DateTime.Now;
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var message = await _context.ChatMessages.FindAsync(id);
            if (message == null) return false;
            _context.ChatMessages.Remove(message);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 
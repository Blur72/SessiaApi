using SessiaApi.Interfaces;
using SessiaApi.Model;
using SessiaApi.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace SessiaApi.Services
{
    public class UserService : IUserService
    {
        private readonly SessiaCarServiceContext _context;
        public UserService(SessiaCarServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.Include(u => u.Role).ToListAsync();
        public async Task<User> GetByIdAsync(int id) => await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 
using SessiaApi.Interfaces;
using SessiaApi.Model;
using SessiaApi.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace SessiaApi.Services
{
    public class CarService : ICarService
    {
        private readonly SessiaCarServiceContext _context;
        public CarService(SessiaCarServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllAsync() => await _context.Cars.Include(c => c.Owner).ToListAsync();
        public async Task<Car> GetByIdAsync(int id) => await _context.Cars.Include(c => c.Owner).FirstOrDefaultAsync(c => c.Id == id);
        public async Task<Car> CreateAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return false;
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 
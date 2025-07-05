using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessiaApi.DataBaseContext;
using SessiaApi.Model;
using SessiaApi.Requests;

namespace SessiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly SessiaCarServiceContext _context;
        public CarController(SessiaCarServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.Include(c => c.Owner).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.Include(c => c.Owner).FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
                return NotFound();
            return car;
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(CreateCarRequest request)
        {
            var car = new Car
            {
                OwnerId = request.OwnerId,
                Brand = request.Brand,
                Model = request.Model,
                LicensePlate = request.LicensePlate,
                Year = request.Year
            };
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return NotFound();
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, UpdateCarRequest request)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();
            car.OwnerId = request.OwnerId;
            car.Brand = request.Brand;
            car.Model = request.Model;
            car.LicensePlate = request.LicensePlate;
            car.Year = request.Year;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 
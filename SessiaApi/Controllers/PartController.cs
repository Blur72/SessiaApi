using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessiaApi.DataBaseContext;
using SessiaApi.Model;
using SessiaApi.Requests;

namespace SessiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartController : ControllerBase
    {
        private readonly SessiaCarServiceContext _context;
        public PartController(SessiaCarServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetParts()
        {
            return await _context.Parts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetPart(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part == null)
                return NotFound();
            return part;
        }

        [HttpPost]
        public async Task<ActionResult<Part>> CreatePart(CreatePartRequest request)
        {
            var part = new Part
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Price = request.Price
            };
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPart), new { id = part.Id }, part);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePart(int id, UpdatePartRequest request)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part == null) return NotFound();
            part.Name = request.Name;
            part.Quantity = request.Quantity;
            part.Price = request.Price;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part == null)
                return NotFound();
            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 
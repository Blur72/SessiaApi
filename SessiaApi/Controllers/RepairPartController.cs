using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessiaApi.DataBaseContext;
using SessiaApi.Model;
using SessiaApi.Requests;

namespace SessiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairPartController : ControllerBase
    {
        private readonly SessiaCarServiceContext _context;
        public RepairPartController(SessiaCarServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairPart>>> GetRepairParts()
        {
            return await _context.RepairParts
                .Include(rp => rp.RepairRequest)
                .Include(rp => rp.Part)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepairPart>> GetRepairPart(int id)
        {
            var repairPart = await _context.RepairParts
                .Include(rp => rp.RepairRequest)
                .Include(rp => rp.Part)
                .FirstOrDefaultAsync(rp => rp.Id == id);
            if (repairPart == null)
                return NotFound();
            return repairPart;
        }

        [HttpPost]
        public async Task<ActionResult<RepairPart>> CreateRepairPart(CreateRepairPartRequest request)
        {
            var repairPart = new RepairPart
            {
                RepairRequestId = request.RepairRequestId,
                PartId = request.PartId,
                Quantity = request.Quantity
            };
            _context.RepairParts.Add(repairPart);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRepairPart), new { id = repairPart.Id }, repairPart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepairPart(int id, UpdateRepairPartRequest request)
        {
            var repairPart = await _context.RepairParts.FindAsync(id);
            if (repairPart == null) return NotFound();
            repairPart.RepairRequestId = request.RepairRequestId;
            repairPart.PartId = request.PartId;
            repairPart.Quantity = request.Quantity;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairPart(int id)
        {
            var repairPart = await _context.RepairParts.FindAsync(id);
            if (repairPart == null)
                return NotFound();
            _context.RepairParts.Remove(repairPart);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 
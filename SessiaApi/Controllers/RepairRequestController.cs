using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessiaApi.DataBaseContext;
using SessiaApi.Model;
using SessiaApi.Requests;

namespace SessiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairRequestController : ControllerBase
    {
        private readonly SessiaCarServiceContext _context;
        public RepairRequestController(SessiaCarServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairRequest>>> GetRepairRequests()
        {
            return await _context.RepairRequests
                .Include(r => r.Car)
                .Include(r => r.Client)
                .Include(r => r.Manager)
                .Include(r => r.Master)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepairRequest>> GetRepairRequest(int id)
        {
            var request = await _context.RepairRequests
                .Include(r => r.Car)
                .Include(r => r.Client)
                .Include(r => r.Manager)
                .Include(r => r.Master)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (request == null)
                return NotFound();
            return request;
        }

        [HttpPost]
        public async Task<ActionResult<RepairRequest>> CreateRepairRequest(CreateRepairRequest request)
        {
            var repairRequest = new RepairRequest
            {
                CarId = request.CarId,
                ClientId = request.ClientId,
                ManagerId = request.ManagerId,
                MasterId = request.MasterId,
                Description = request.Description,
                Status = request.Status,
                DesiredDate = request.DesiredDate,
                CreatedAt = DateTime.Now
            };
            _context.RepairRequests.Add(repairRequest);
            await _context.SaveChangesAsync();
            var statusHistory = new RepairRequestStatusHistory
            {
                RepairRequestId = repairRequest.Id,
                Status = repairRequest.Status,
                ChangedAt = DateTime.Now,
                ChangedById = repairRequest.ClientId,
                Comment = "Создание заявки"
            };
            _context.RepairRequestStatusHistories.Add(statusHistory);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRepairRequest), new { id = repairRequest.Id }, repairRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepairRequest(int id, UpdateRepairRequest request)
        {
            var repairRequest = await _context.RepairRequests.FindAsync(id);
            if (repairRequest == null) return NotFound();
            bool statusChanged = repairRequest.Status != request.Status;
            repairRequest.CarId = request.CarId;
            repairRequest.ClientId = request.ClientId;
            repairRequest.ManagerId = request.ManagerId;
            repairRequest.MasterId = request.MasterId;
            repairRequest.Description = request.Description;
            repairRequest.Status = request.Status;
            repairRequest.DesiredDate = request.DesiredDate;
            repairRequest.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            if (statusChanged)
            {
                var statusHistory = new RepairRequestStatusHistory
                {
                    RepairRequestId = repairRequest.Id,
                    Status = repairRequest.Status,
                    ChangedAt = DateTime.Now,
                    ChangedById = request.ManagerId ?? request.MasterId ?? request.ClientId,
                    Comment = "Изменение статуса"
                };
                _context.RepairRequestStatusHistories.Add(statusHistory);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairRequest(int id)
        {
            var request = await _context.RepairRequests.FindAsync(id);
            if (request == null)
                return NotFound();
            _context.RepairRequests.Remove(request);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id}/statushistory")]
        public async Task<ActionResult<IEnumerable<RepairRequestStatusHistory>>> GetStatusHistory(int id)
        {
            var history = await _context.RepairRequestStatusHistories
                .Where(h => h.RepairRequestId == id)
                .OrderBy(h => h.ChangedAt)
                .ToListAsync();
            return history;
        }
    }
} 
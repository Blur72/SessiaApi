using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessiaApi.DataBaseContext;
using SessiaApi.Model;
using SessiaApi.Requests;

namespace SessiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairReportController : ControllerBase
    {
        private readonly SessiaCarServiceContext _context;

        public RepairReportController(SessiaCarServiceContext context)
        {
            _context = context;
        }

        // GET: api/repairreport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairReport>>> GetRepairReports()
        {
            return await _context.RepairReports
                .Include(r => r.RepairRequest)
                .Include(r => r.Master)
                .ToListAsync();
        }

        // GET: api/repairreport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairReport>> GetRepairReport(int id)
        {
            var repairReport = await _context.RepairReports
                .Include(r => r.RepairRequest)
                .Include(r => r.Master)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (repairReport == null)
            {
                return NotFound();
            }

            return repairReport;
        }

        // GET: api/repairreport/byrequest/5
        [HttpGet("byrequest/{requestId}")]
        public async Task<ActionResult<RepairReport>> GetRepairReportByRequest(int requestId)
        {
            var repairReport = await _context.RepairReports
                .Include(r => r.RepairRequest)
                .Include(r => r.Master)
                .FirstOrDefaultAsync(r => r.RepairRequestId == requestId);

            if (repairReport == null)
            {
                return NotFound();
            }

            return repairReport;
        }

        // POST: api/repairreport
        [HttpPost]
        public async Task<ActionResult<RepairReport>> CreateRepairReport(CreateRepairReportRequest request)
        {
            var repairReport = new RepairReport
            {
                RepairRequestId = request.RepairRequestId,
                MasterId = request.MasterId,
                ReportText = request.ReportText,
                CreatedAt = DateTime.Now
            };

            _context.RepairReports.Add(repairReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRepairReport), new { id = repairReport.Id }, repairReport);
        }

        // PUT: api/repairreport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepairReport(int id, UpdateRepairReportRequest request)
        {
            var repairReport = await _context.RepairReports.FindAsync(id);
            if (repairReport == null)
            {
                return NotFound();
            }

            repairReport.RepairRequestId = request.RepairRequestId;
            repairReport.MasterId = request.MasterId;
            repairReport.ReportText = request.ReportText;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/repairreport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairReport(int id)
        {
            var repairReport = await _context.RepairReports.FindAsync(id);
            if (repairReport == null)
            {
                return NotFound();
            }

            _context.RepairReports.Remove(repairReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairReportExists(int id)
        {
            return _context.RepairReports.Any(e => e.Id == id);
        }
    }
} 
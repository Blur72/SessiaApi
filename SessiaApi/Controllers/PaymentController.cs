using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessiaApi.DataBaseContext;
using SessiaApi.Model;
using SessiaApi.Requests;

namespace SessiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly SessiaCarServiceContext _context;
        public PaymentController(SessiaCarServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Payments
                .Include(p => p.RepairRequest)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.RepairRequest)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (payment == null)
                return NotFound();
            return payment;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayment(CreatePaymentRequest request)
        {
            var payment = new Payment
            {
                RepairRequestId = request.RepairRequestId,
                Amount = request.Amount,
                PaidAt = request.PaidAt,
                Status = request.Status
            };
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, UpdatePaymentRequest request)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();
            payment.RepairRequestId = request.RepairRequestId;
            payment.Amount = request.Amount;
            payment.PaidAt = request.PaidAt;
            payment.Status = request.Status;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return NotFound();
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 
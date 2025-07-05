using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessiaApi.DataBaseContext;
using SessiaApi.Model;
using SessiaApi.Requests;

namespace SessiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly SessiaCarServiceContext _context;
        public ReviewController(SessiaCarServiceContext context)
        {
            _context = context;
        }

        // POST: api/review
        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview(CreateReviewRequest request)
        {
            var review = new Review
            {
                RepairRequestId = request.RepairRequestId,
                ClientId = request.ClientId,
                MasterId = request.MasterId,
                Rating = request.Rating,
                Comment = request.Comment,
                CreatedAt = DateTime.Now
            };
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReviewByRequest), new { requestId = review.RepairRequestId }, review);
        }

        // GET: api/review/byrequest/5
        [HttpGet("byrequest/{requestId}")]
        public async Task<ActionResult<Review>> GetReviewByRequest(int requestId)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.RepairRequestId == requestId);
            if (review == null)
                return NotFound();
            return review;
        }

        // GET: api/review/bymaster/5
        [HttpGet("bymaster/{masterId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByMaster(int masterId)
        {
            var reviews = await _context.Reviews.Where(r => r.MasterId == masterId).ToListAsync();
            return reviews;
        }
    }
} 
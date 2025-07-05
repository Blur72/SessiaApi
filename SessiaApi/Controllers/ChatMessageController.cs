using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessiaApi.DataBaseContext;
using SessiaApi.Model;
using SessiaApi.Requests;

namespace SessiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatMessageController : ControllerBase
    {
        private readonly SessiaCarServiceContext _context;
        public ChatMessageController(SessiaCarServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMessage>>> GetChatMessages()
        {
            return await _context.ChatMessages
                .Include(m => m.RepairRequest)
                .Include(m => m.Sender)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatMessage>> GetChatMessage(int id)
        {
            var message = await _context.ChatMessages
                .Include(m => m.RepairRequest)
                .Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
                return NotFound();
            return message;
        }

        [HttpPost]
        public async Task<ActionResult<ChatMessage>> CreateChatMessage(CreateChatMessageRequest request)
        {
            var message = new ChatMessage
            {
                RepairRequestId = request.RepairRequestId,
                SenderId = request.SenderId,
                MessageText = request.MessageText,
                SentAt = DateTime.Now
            };
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetChatMessage), new { id = message.Id }, message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatMessage(int id)
        {
            var message = await _context.ChatMessages.FindAsync(id);
            if (message == null)
                return NotFound();
            _context.ChatMessages.Remove(message);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("byrequest/{requestId}")]
        public async Task<ActionResult<IEnumerable<ChatMessage>>> GetByRequest(int requestId)
        {
            var messages = await _context.ChatMessages
                .Where(m => m.RepairRequestId == requestId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
            return messages;
        }
    }
} 
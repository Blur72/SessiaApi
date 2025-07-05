using System.Text.Json.Serialization;

namespace SessiaBlazor.Model
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int RepairRequestId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        [JsonPropertyName("MessageText")]
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
} 
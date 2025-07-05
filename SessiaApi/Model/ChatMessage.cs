using System;

namespace SessiaApi.Model
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int RepairRequestId { get; set; }
        public RepairRequest RepairRequest { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime SentAt { get; set; }
    }
} 
using System;

namespace SessiaApi.Model
{
    public class Review
    {
        public int Id { get; set; }
        public int RepairRequestId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public int Rating { get; set; } // 1-5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 
using System;

namespace SessiaBlazor.Model
{
    public class Review
    {
        public int Id { get; set; }
        public int RepairRequestId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 
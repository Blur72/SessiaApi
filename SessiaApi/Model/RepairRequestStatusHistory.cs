using System;

namespace SessiaApi.Model
{
    public class RepairRequestStatusHistory
    {
        public int Id { get; set; }
        public int RepairRequestId { get; set; }
        public string Status { get; set; }
        public DateTime ChangedAt { get; set; }
        public int? ChangedById { get; set; }
        public string Comment { get; set; }

        public RepairRequest RepairRequest { get; set; }
        public User ChangedBy { get; set; }
    }
} 
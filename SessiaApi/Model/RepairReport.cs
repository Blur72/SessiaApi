using System;

namespace SessiaApi.Model
{
    public class RepairReport
    {
        public int Id { get; set; }
        public int RepairRequestId { get; set; }
        public RepairRequest RepairRequest { get; set; }
        public int MasterId { get; set; }
        public User Master { get; set; }
        public string ReportText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 
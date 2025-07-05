using System;

namespace SessiaApi.Requests
{
    public class UpdatePaymentRequest
    {
        public int RepairRequestId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaidAt { get; set; }
        public string Status { get; set; }
    }
} 
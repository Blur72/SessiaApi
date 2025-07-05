namespace SessiaBlazor.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public int RepairRequestId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime? PaidAt { get; set; }
    }
} 
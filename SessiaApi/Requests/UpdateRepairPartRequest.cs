namespace SessiaApi.Requests
{
    public class UpdateRepairPartRequest
    {
        public int RepairRequestId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
    }
} 
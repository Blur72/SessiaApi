namespace SessiaBlazor.Model
{
    public class RepairPart
    {
        public int Id { get; set; }
        public int RepairRequestId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
        public Part Part { get; set; }
    }
} 
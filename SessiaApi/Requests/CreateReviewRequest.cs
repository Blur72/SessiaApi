namespace SessiaApi.Requests
{
    public class CreateReviewRequest
    {
        public int RepairRequestId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
} 
namespace SessiaApi.Requests
{
    public class CreateChatMessageRequest
    {
        public int RepairRequestId { get; set; }
        public int SenderId { get; set; }
        public string MessageText { get; set; }
    }
} 
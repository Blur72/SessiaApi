namespace SessiaApi.Requests
{
    public class CreateRepairReportRequest
    {
        public int RepairRequestId { get; set; }
        public int MasterId { get; set; }
        public string ReportText { get; set; }
    }
} 
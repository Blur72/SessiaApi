namespace SessiaApi.Requests
{
    public class UpdateRepairReportRequest
    {
        public int RepairRequestId { get; set; }
        public int MasterId { get; set; }
        public string ReportText { get; set; }
    }
} 
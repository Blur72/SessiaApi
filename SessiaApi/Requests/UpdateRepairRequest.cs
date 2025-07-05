using System;

namespace SessiaApi.Requests
{
    public class UpdateRepairRequest
    {
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public int? ManagerId { get; set; }
        public int? MasterId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? DesiredDate { get; set; }
    }
} 
using System;

namespace SessiaBlazor.Model
{
    public class CreateRepairRequest
    {
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DesiredDate { get; set; }
    }
} 
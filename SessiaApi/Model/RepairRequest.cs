using System;

namespace SessiaApi.Model
{
    public class RepairRequest
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int ClientId { get; set; }
        public User Client { get; set; }
        public int? ManagerId { get; set; }
        public User Manager { get; set; }
        public int? MasterId { get; set; }
        public User Master { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DesiredDate { get; set; }
    }
} 
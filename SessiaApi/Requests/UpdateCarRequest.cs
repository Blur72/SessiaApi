namespace SessiaApi.Requests
{
    public class UpdateCarRequest
    {
        public int OwnerId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int? Year { get; set; }
    }
} 
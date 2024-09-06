namespace APINetBackMVC.Models.Entities
{
    public class Fee
    {
        public int Id { get; set; } // Primary Key
        public DateTime Timestamp { get; set; }
        public DateTime TimestampUTC { get; set; }
        public required string Country { get; set; }
        public decimal? ImbalanceFee { get; set; }
        public decimal? HourlyImbalanceFee { get; set; }
        public decimal? PeakLoadFee { get; set; }
        public decimal? VolumeFee { get; set; }
        public decimal WeeklyFee { get; set; }
    }
}

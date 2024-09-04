namespace APINetBackMVC.Models.Entities
{
    public class Fees
    {
        public required string Country { get; set; }
        public required string Timestamp { get; set; }
        public required string TimestampUTC { get; set; }
        public int HourlyImbalanceFee {  get; set; }
        public int ImbalanceFee { get; set; }
        public int PeakLoadFee { get; set; }
        public int VolumeFee { get; set; }
        public int WeeklyFee { get; set; }
    }
}

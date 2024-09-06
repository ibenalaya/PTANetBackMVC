namespace APINetBackMVC.Models.Entities
{
    public class Bank
    {
        public required string BIC { get; set; } //Primary Key
        public required string Country { get; set; }
        public required string Name { get; set; }
    }
}

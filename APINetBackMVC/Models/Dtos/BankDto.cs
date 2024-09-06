namespace APINetBackMVC.Models.Dtos
{
    public class BankDto
    { 
        public required string BIC { get; set; } //Primary Key
        public required string Country { get; set; }
        public required string Name { get; set; }
    }
}

namespace APINetBackMVC.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

        public int StatusCode { get; set; }
    }
}

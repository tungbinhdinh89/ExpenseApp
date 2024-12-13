namespace ExpenseApp.DTOs
{
    public class ExpenseDTO
    {
        public string Category { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

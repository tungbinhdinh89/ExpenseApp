namespace ExpenseApp.Data.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Category { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}

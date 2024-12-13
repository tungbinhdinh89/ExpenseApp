namespace ExpenseApp.Data.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Profile? Profile { get; set; }
    }
}

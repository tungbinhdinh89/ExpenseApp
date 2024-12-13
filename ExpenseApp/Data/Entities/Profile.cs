namespace ExpenseApp.Data.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public ICollection<Expense>? Expenses { get; set; }
    }
}

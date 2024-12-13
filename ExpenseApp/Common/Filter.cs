namespace ExpenseApp.Common
{
    public record Filter
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}

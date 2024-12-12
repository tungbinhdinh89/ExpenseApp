using System.ComponentModel.DataAnnotations;

namespace ExpenseApp.Data.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, MaxLength(255)]
        public string FullName { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}

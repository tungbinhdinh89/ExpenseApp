using ExpenseApp.DTOs;

namespace ExpenseApp.Models
{
    public class ProfileDTO
    {
        public string Email { get; set; } = String.Empty;
        public string FullName { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public ICollection<ExpenseDTO>? Expenses { get; set; }
    }
}

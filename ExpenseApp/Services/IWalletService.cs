using ExpenseApp.Common;
using ExpenseApp.DTOs;
using ExpenseApp.Extensions;

namespace ExpenseApp.Services
{
    public interface IWalletService
    {
        Task<Result<int>> AddExpenses(List<ExpenseDTO> expenses, string userEmail);
        Task<Result<int>> UpdateExpense(int id, string userEmail, ExpenseDTO expense);
        Task<Result<List<ExpenseDTO>>> ReportExpenses(string userEmail, Filter filter);
    }
}

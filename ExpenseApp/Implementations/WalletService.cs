using ExpenseApp.Data;
using ExpenseApp.Data.Entities;
using ExpenseApp.DTOs;
using ExpenseApp.Extensions;
using ExpenseApp.Services;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Implementations
{
    public class WalletService(ExpenseDbContext dbContext) : IWalletService
    {
        public async Task<Result<int>> AddExpenses(List<ExpenseDTO> expenses, string userEmail)
        {
            var profile = await dbContext.Profiles.AsNoTracking().FirstOrDefaultAsync(p => p.Email == userEmail);
            if (profile == null) return Result<int>.Fail(ResultCode.PROFILE_DOES_NOT_EXIST);

            var entity = expenses.Select(e => new Expense
            {
                ProfileId = profile.Id,
                Category = e.Category,
                Description = e.Description,
                Price = e.Price,
                CreatedAt = e.CreatedAt ?? DateTime.Now
            }).ToList();

            dbContext.Expenses.AddRange(entity);
            await dbContext.SaveChangesAsync();

            return Result<int>.Ok(entity.Count, "Expense added successfully");
        }

        public async Task<Result<List<ExpenseDTO>>> ReportExpenses(string userEmail, DateTime from, DateTime to)
        {
            var profile = await dbContext.Profiles.AsNoTracking().FirstOrDefaultAsync(p => p.Email == userEmail);
            if (profile == null) return Result<List<ExpenseDTO>>.Fail(ResultCode.PROFILE_DOES_NOT_EXIST);

            var report = await dbContext.Expenses.Where(e => e.ProfileId == profile.Id && e.CreatedAt >= from && e.CreatedAt <= to)
                                                 .Select(e => new ExpenseDTO
                                                 {
                                                     Category = e.Category,
                                                     Description = e.Description,
                                                     Price = e.Price,
                                                     CreatedAt = e.CreatedAt
                                                 })
                                                 .OrderBy(e => e.CreatedAt)
                                                 .ToListAsync();
            return Result<List<ExpenseDTO>>.Ok(report, "Get report expenses successfully");
        }

        public async Task<Result<int>> UpdateExpense(int id, string userEmail, ExpenseDTO expense)
        {
            if (await dbContext.Profiles.AsNoTracking().FirstOrDefaultAsync(p => p.Email == userEmail) == null) return Result<int>.Fail(ResultCode.PROFILE_DOES_NOT_EXIST);

            var entity = await dbContext.Expenses.FirstOrDefaultAsync(p => p.Id == id);
            if (entity == null) return Result<int>.Fail(ResultCode.EXPENSE_DOES_NOT_EXIST);

            entity.Category = expense.Category;
            entity.Description = expense.Description;
            entity.Price = expense.Price;
            entity.CreatedAt = expense.CreatedAt ?? entity.CreatedAt;

            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();

            return Result<int>.Ok(entity.Id, "Expense added successfully");

        }
    }
}

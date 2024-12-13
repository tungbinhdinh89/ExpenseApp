using ExpenseApp.Data;
using ExpenseApp.Data.Entities;
using ExpenseApp.Exceptions;
using ExpenseApp.Extensions;
using ExpenseApp.Models;
using ExpenseApp.Services;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Implementations
{
    public class ProfileService(ExpenseDbContext dbContext) : IProfileService
    {
        public async Task<Result<int>> AddProfile(ProfileDTO profile)
        {
            if (await dbContext.Profiles.AsNoTracking().AnyAsync(p => p.Email == profile.Email)) return Result<int>.Fail(ResultCode.PROFILE_ALREADY_EXIST);

            var entity = new Profile
            {
                Email = profile.Email,
                FullName = profile.FullName,
                Phone = profile.Phone,
                Expenses = profile.Expenses?.Select(e => new Expense
                {
                    Category = e.Category,
                    Description = e.Description,
                    Price = e.Price,
                    CreatedAt = e.CreatedAt,
                }).ToList()
            };

            dbContext.Profiles.Add(entity);
            await dbContext.SaveChangesAsync();
            return Result<int>.Ok(entity.Id, "Profile added successfully");
        }

        public async Task<ProfileDTO> GetProfile(string email)
        {
            var profile = await dbContext.Profiles.AsNoTracking().Where(p => p.Email == email).Select(p => new ProfileDTO
            {
                Email = p.Email,
                FullName = p.FullName,
                Phone = p.Phone,
            }).FirstOrDefaultAsync();

            if (profile == null) throw new EntityNotFoundException("Profile not found");
            return profile;
        }
    }
}

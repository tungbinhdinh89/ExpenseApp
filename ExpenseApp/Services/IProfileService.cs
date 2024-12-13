using ExpenseApp.Extensions;
using ExpenseApp.Models;

namespace ExpenseApp.Services
{
    public interface IProfileService
    {
        Task<Result<int>> AddProfile(ProfileDTO profile);
        Task<ProfileDTO> GetProfile(String email);
    }
}

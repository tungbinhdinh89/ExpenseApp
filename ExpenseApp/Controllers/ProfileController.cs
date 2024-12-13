using ExpenseApp.Models;
using ExpenseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController(IProfileService profileService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddProfile([FromBody] ProfileDTO profile)
        {
            var result = await profileService.AddProfile(profile);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile(string email)
        {
            var result = await profileService.GetProfile(email);
            return Ok(result);
        }
    }

}

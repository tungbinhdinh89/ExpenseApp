using ExpenseApp.Common;
using ExpenseApp.DTOs;
using ExpenseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController(IWalletService walletService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddExpenses([FromBody] List<ExpenseDTO> expenses, [FromHeader(Name = "user")] string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest(new { errors = new { email = new[] { "The email field is required." } } });
            }

            var response = expenses.Select(e => new ExpenseDTO
            {
                Category = e.Category,
                Description = e.Description,
                Price = e.Price,
                CreatedAt = e.CreatedAt
            }).ToList();

            await walletService.AddExpenses(response, userEmail);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, [FromHeader(Name = "user")] string userEmail, ExpenseDTO expense)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest(new { errors = new { email = new[] { "The email field is required." } } });
            }

            var response = new ExpenseDTO
            {
                Category = expense.Category,
                Description = expense.Description,
                Price = expense.Price,
                CreatedAt = expense.CreatedAt
            };

            await walletService.UpdateExpense(id, userEmail, expense);

            return Ok(response);
        }


        [HttpGet("report")]
        public async Task<IActionResult> ReportExpenses([FromHeader(Name = "user")] string userEmail, [FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var filter = new Filter
            {
                From = from,
                To = to
            };
            var result = await walletService.ReportExpenses(userEmail, filter);
            return Ok(result);
        }
    }
}

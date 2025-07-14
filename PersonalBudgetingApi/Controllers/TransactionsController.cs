using Microsoft.AspNetCore.Mvc;
using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Services.Interfaces;
using PersonalBudgetingApi.DTO;

namespace PersonalBudgetingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController(ITransactionService transactionService) : ControllerBase
{
    private readonly ITransactionService _transactionService = transactionService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
    {
        var transactions = await _transactionService.GetAllAsync();
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetTransaction(int id)
    {
        var transaction = await _transactionService.GetByIdAsync(id);
        if (transaction == null)
        {
            return NotFound();
        }
        return Ok(transaction);
    }

    [HttpPost]
    public async Task<ActionResult<Transaction>> CreateTransaction(TransactionDto transaction)
    {
        var created = await _transactionService.CreateAsync(transaction);
        return CreatedAtAction(nameof(GetTransaction), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransaction(int id, TransactionDto dto)
    {
        var updated = await _transactionService.UpdateAsync(id, dto);

        if (!updated)
            return NotFound($"Transaction with ID {id} was not found.");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var deleted = await _transactionService.DeleteAsync(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}

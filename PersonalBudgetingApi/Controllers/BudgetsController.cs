using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBudgetingApi.DTO;
using PersonalBudgetingApi.Services.Interfaces;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminAndHigher")]
public class BudgetsController : ControllerBase
{
    private readonly IBudgetService _budgetService;

    public BudgetsController(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    private int GetUserId() =>
        int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

    [HttpPost]
    public async Task<IActionResult> Create(BudgetDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _budgetService.CreateBudgetAsync(dto, GetUserId());
        return CreatedAtAction(nameof(GetById), new { id = result!.Id }, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var budgets = await _budgetService.GetBudgetsAsync(GetUserId());
        return Ok(budgets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var budget = await _budgetService.GetBudgetByIdAsync(id, GetUserId());
        return budget == null ? NotFound() : Ok(budget);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, BudgetDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var success = await _budgetService.UpdateBudgetAsync(id, dto, GetUserId());
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _budgetService.DeleteBudgetAsync(id, GetUserId());
        return success ? NoContent() : NotFound();
    }
}

using CoffeShopApi.Models;
using CoffeShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BreakfastsController : ControllerBase
{
  private readonly BreakfastsService _breakfastsService;

  public BreakfastsController(BreakfastsService breakfastsService) =>
      _breakfastsService = breakfastsService;

  [HttpGet]
  public async Task<List<Breakfast>> Get() =>
      await _breakfastsService.GetAsync();

  [HttpGet("{hashCode}")]
  public async Task<ActionResult<List<Breakfast>>> GetAll(long hashCode)
  {
    var breakfasts = await _breakfastsService.GetAllByHashAsync(hashCode);

    if (breakfasts is [])
    {
      return NotFound();
    }

    return breakfasts;
  }

  [HttpGet("getAll")]
  public async Task<IEnumerable<Breakfast>> GetListByIds([FromQuery] List<string> ids)
  {
    return await _breakfastsService.GetAllByIdsAsync(ids);
  }

  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<Breakfast>> Get(string id)
  {
    var breakfast = await _breakfastsService.GetAsync(id);

    if (breakfast is null)
    {
      return NotFound();
    }

    return breakfast;
  }

  [HttpPost]
  public async Task<IActionResult> Post(Breakfast newBreakfast)
  {
    await _breakfastsService.CreateAsync(newBreakfast);

    return CreatedAtAction(nameof(Get), new { id = newBreakfast.id }, newBreakfast);
  }

  [HttpPut("{id:length(24)}")]
  public async Task<IActionResult> Update(string id, Breakfast updatedBreakfast)
  {
    var breakfast = await _breakfastsService.GetAsync(id);

    if (breakfast is null)
    {
      return NotFound();
    }

    updatedBreakfast.id = breakfast.id;

    await _breakfastsService.UpdateAsync(id, updatedBreakfast);

    return NoContent();
  }

  [HttpDelete("{id:length(24)}")]
  public async Task<IActionResult> Delete(string id)
  {
    var breakfast = await _breakfastsService.GetAsync(id);

    if (breakfast is null)
    {
      return NotFound();
    }

    await _breakfastsService.RemoveAsync(id);

    return NoContent();
  }
}
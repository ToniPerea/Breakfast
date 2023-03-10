using AutoMapper;
using CoffeShopApi.Models;
using CoffeShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MealsController : ControllerBase
{
  private readonly MealsService _mealsService;

  private readonly IMapper _mapper;

  public MealsController(MealsService mealsService, IMapper mapper)
  {
    _mealsService = mealsService;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var items = await _mealsService.GetAsync();

    var mealsList = _mapper.Map<IEnumerable<MealDTO>>(items);

    return Ok(mealsList);
  }

  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<Meal>> Get(string id)
  {
    var meal = await _mealsService.GetAsync(id);

    if (meal is null)
    {
      return NotFound();
    }

    return meal;
  }

  [HttpPost]
  public async Task<IActionResult> Post(MealCreationDTO newMeal)
  {
    var _newMeal = _mapper.Map<Meal>(newMeal);

    if (ModelState.IsValid)
    {
      await _mealsService.CreateAsync(_newMeal);

      return CreatedAtAction(nameof(Get), new { id = _newMeal.id }, newMeal);
    }

    return new JsonResult("Something went wrong") { StatusCode = 500 };
  }

  [HttpPut("{id:length(24)}")]
  public async Task<IActionResult> Update(string id, Meal updatedMeal)
  {
    var meal = await _mealsService.GetAsync(id);

    if (meal is null)
    {
      return NotFound();
    }

    updatedMeal.id = meal.id;

    await _mealsService.UpdateAsync(id, updatedMeal);

    return NoContent();
  }

  [HttpDelete("{id:length(24)}")]
  public async Task<IActionResult> Delete(string id)
  {
    var meal = await _mealsService.GetAsync(id);

    if (meal is null)
    {
      return NotFound();
    }

    await _mealsService.RemoveAsync(id);

    return NoContent();
  }
}
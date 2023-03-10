using AutoMapper;
using CoffeShopApi.Models;
using CoffeShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrinksController : ControllerBase
{
  private readonly DrinksService _drinksService;

  private readonly IMapper _mapper;

  public DrinksController(DrinksService drinksService, IMapper mapper)
  {
    _drinksService = drinksService;
    _mapper = mapper;
  }

  [HttpGet]
   public async Task<IActionResult> Get()
  {
    var items = await _drinksService.GetAsync();

    var drinksList = _mapper.Map<IEnumerable<DrinkDTO>>(items);

    return Ok(drinksList);
  }

  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<Drink>> Get(string id)
  {
    var drink = await _drinksService.GetAsync(id);

    if (drink is null)
    {
      return NotFound();
    }

    return drink;
  }

  [HttpPost]
  public async Task<IActionResult> Post(DrinkCreationDTO newDrink)
  {
    var _newDrink = _mapper.Map<Drink>(newDrink);

    if (ModelState.IsValid)
    {
      await _drinksService.CreateAsync(_newDrink);

      return CreatedAtAction(nameof(Get), new { id = _newDrink.id }, newDrink);
    }

    return new JsonResult("Something went wrong") { StatusCode = 500 };
  }

  [HttpPut("{id:length(24)}")]
  public async Task<IActionResult> Update(string id, Drink updatedDrink)
  {
    var drink = await _drinksService.GetAsync(id);

    if (drink is null)
    {
      return NotFound();
    }

    updatedDrink.id = drink.id;

    await _drinksService.UpdateAsync(id, updatedDrink);

    return NoContent();
  }

  [HttpDelete("{id:length(24)}")]
  public async Task<IActionResult> Delete(string id)
  {
    var drink = await _drinksService.GetAsync(id);

    if (drink is null)
    {
      return NotFound();
    }

    await _drinksService.RemoveAsync(id);

    return NoContent();
  }
}
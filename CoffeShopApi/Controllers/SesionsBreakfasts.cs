// using CoffeShopApi.Models;
// using CoffeShopApi.Services;
// using Microsoft.AspNetCore.Mvc;

// namespace CoffeShopApi.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class SesionsBreakfastsController : ControllerBase
// {
//     private readonly SesionsBreakfastsService _sesionsBreakfastsService;

//     public SesionsBreakfastsController(SesionsBreakfastsService sesionsBreakfastsService) =>
//         _sesionsBreakfastsService = sesionsBreakfastsService;

//     [HttpGet]
//     public async Task<List<SesionBreakfast>> Get() =>
//         await _sesionsBreakfastsService.GetAsync();

//     [HttpGet("{sesionHashCode}")]
//     public async Task<List<SesionBreakfast>> GetAll(long sesionHashCode)
//     {
//         var sesionsBreakfasts = await _sesionsBreakfastsService.GetAllAsync(sesionHashCode);

//         return sesionsBreakfasts;
//     }

//     [HttpGet("{id:length(24)}")]
//     public async Task<ActionResult<SesionBreakfast>> Get(string id)
//     {
//         var sesion = await _sesionsBreakfastsService.GetAsync(id);

//         if (sesion is null)
//         {
//             return NotFound();
//         }

//         return sesion;
//     }

//     [HttpPost]
//     public async Task<IActionResult> Post(SesionBreakfast newSesion)
//     {
//         await _sesionsBreakfastsService.CreateAsync(newSesion);

//         return CreatedAtAction(nameof(Get), new { id = newSesion.id }, newSesion);
//     }

//     [HttpPut("{id:length(24)}")]
//     public async Task<IActionResult> Update(string id, SesionBreakfast updatedSesion)
//     {
//         var sesion = await _sesionsBreakfastsService.GetAsync(id);

//         if (sesion is null)
//         {
//             return NotFound();
//         }

//         updatedSesion.id = sesion.id;

//         await _sesionsBreakfastsService.UpdateAsync(id, updatedSesion);

//         return NoContent();
//     }

//     [HttpDelete("{id:length(24)}")]
//     public async Task<IActionResult> Delete(string id)
//     {
//         var sesion = await _sesionsBreakfastsService.GetAsync(id);

//         if (sesion is null)
//         {
//             return NotFound();
//         }

//         await _sesionsBreakfastsService.RemoveAsync(id);

//         return NoContent();
//     }
// }
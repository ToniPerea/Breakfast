// using CoffeShopApi.Models;
// using CoffeShopApi.Services;
// using Microsoft.AspNetCore.Mvc;

// namespace CoffeShopApi.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class SesionsController : ControllerBase
// {
//     private readonly SesionsService _sesionsService;

//     public SesionsController(SesionsService sesionsService) =>
//         _sesionsService = sesionsService;

//     [HttpGet]
//     public async Task<List<Sesion>> Get() =>
//         await _sesionsService.GetAsync();

//     [HttpGet("{hashCode}")]
//     public async Task<List<Sesion>> GetAll(long hashCode)
//     {
//         var sesions = await _sesionsService.GetAllAsync(hashCode);

//         return sesions;
//     }

//     [HttpGet("{id:length(24)}")]
//     public async Task<ActionResult<Sesion>> Get(string id)
//     {
//         var sesion = await _sesionsService.GetAsync(id);

//         if (sesion is null)
//         {
//             return NotFound();
//         }

//         return sesion;
//     }

//     [HttpPost]
//     public async Task<IActionResult> Post(Sesion newSesion)
//     {
//         await _sesionsService.CreateAsync(newSesion);

//         return CreatedAtAction(nameof(Get), new { id = newSesion.id }, newSesion);
//     }

//     [HttpPut("{id:length(24)}")]
//     public async Task<IActionResult> Update(string id, Sesion updatedSesion)
//     {
//         var sesion = await _sesionsService.GetAsync(id);

//         if (sesion is null)
//         {
//             return NotFound();
//         }

//         updatedSesion.id = sesion.id;

//         await _sesionsService.UpdateAsync(id, updatedSesion);

//         return NoContent();
//     }

//     [HttpDelete("{id:length(24)}")]
//     public async Task<IActionResult> Delete(string id)
//     {
//         var sesion = await _sesionsService.GetAsync(id);

//         if (sesion is null)
//         {
//             return NotFound();
//         }

//         await _sesionsService.RemoveAsync(id);

//         return NoContent();
//     }
// }
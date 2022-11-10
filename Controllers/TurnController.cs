using Microsoft.AspNetCore.Mvc;
using Saturno_Backend.Services;
using Saturno_Backend.Data.Models;
using Saturno_Backend.Data.Dto;

namespace Saturno_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TurnController : ControllerBase {

    public readonly TurnServices _service;
    public TurnController(TurnServices turn)
    {
        _service = turn;
    }

    [HttpGet]
    public async Task<IEnumerable<Turn>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Turn>> GetById(int id)
    {
        var turn = await _service.GetById(id);
        
        if(turn is null)
        {
            return NotFound();
        }

       return turn;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TurnDTO turn)
    {
        var newTurn = await _service.Create(turn);

        return CreatedAtAction(nameof(GetById), new {id = newTurn.Id}, newTurn);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Turn turn)
    {
        if (id != turn.Id)
        {
            return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({turn.Id}) de la Body Request." });
        }
         
         var turnToUpdate = await _service.GetById(id);

         if(turnToUpdate != null)
         {
            await _service.Update(id, turn);
            return NoContent();
         }else{
            return NotFound();
         }
    }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

         var TurnToDelete = await _service.GetById(id);

         if(TurnToDelete != null)
         {
            await _service.Delete(id);
            return Ok();

         } else{ return NotFound(); } 

        }
}
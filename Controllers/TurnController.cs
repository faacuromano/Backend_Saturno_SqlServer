using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Saturno_Backend.Services;
using Saturno_Backend.Data.Models;

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
        var appointment = await _service.GetById(id);
        
        if(appointment is null)
        {
            return NotFound();
        }

       return appointment;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Turn appointment)
    {
        var newAppointment = await _service.Create(appointment);

        return CreatedAtAction(nameof(GetById), new {id = newAppointment.Id}, newAppointment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Turn appointment)
    {
        if (id != appointment.Id)
        {
            return BadRequest();
        }
         
         var appointmentToUpdate = await _service.GetById(id);

         if(appointmentToUpdate != null)
         {
            await _service.Update(id, appointment);
            return NoContent();
         }else{
            return NotFound();
         }
    }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

         var AppointmentToDelete = await _service.GetById(id);

         if(AppointmentToDelete != null)
         {
            await _service.Delete(id);
            return Ok();

         }else{

            return NotFound();
            
         } 
        }

}
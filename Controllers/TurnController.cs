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
    public IEnumerable<Turn> Get()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Turn> GetById(int id)
    {
        var appointment = _service.GetById(id);
        
        if(appointment is null)
        {
            return NotFound();
        }

       return appointment;
    }

    [HttpPost]
    public IActionResult Create(Turn appointment)
    {
        var newAppointment = _service.Create(appointment);

        return CreatedAtAction(nameof(GetById), new {id = newAppointment.Id}, newAppointment);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Turn appointment)
    {
        if (id != appointment.Id)
        {
            return BadRequest();
        }
         
         var appointmentToUpdate = _service.GetById(id);

         if(appointmentToUpdate != null)
         {
            _service.Update(id, appointment);
            return NoContent();
         }else{
            return NotFound();
         }
    }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

         var AppointmentToDelete = _service.GetById(id);

         if(AppointmentToDelete != null)
         {
            _service.Delete(id);
            return Ok();

         }else{

            return NotFound();
            
         } 
        }

}
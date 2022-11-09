using Microsoft.AspNetCore.Mvc;
using Saturno_Backend.Services;
using Saturno_Backend.Data.Models;

namespace Saturno_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceController : ControllerBase {

    public readonly ServiceService _service;
    public ServiceController(ServiceService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Service> Get()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Service> GetById(int id)
    {
        var service = _service.GetById(id);
        
        if(service is null)
        {
            return NotFound();
        }

       return service;
    }

    [HttpPost]
    public IActionResult Create(Service service)
    {
        var newService = _service.Create(service);

        return CreatedAtAction(nameof(GetById), new {id = newService.Id}, newService);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Service service)
    {
        if (id != service.Id)
        {
            return BadRequest();
        }
         
         var serviceToUpdate = _service.GetById(id);

         if(serviceToUpdate != null)
         {
            _service.Update(id, service);
            return NoContent();
         }else{
            return NotFound();
         }
    }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

         var serviceToDelete = _service.GetById(id);

         if(serviceToDelete != null)
         {
            _service.Delete(id);
            return Ok();

         }else{

            return NotFound();
            
         } 
        }

}
using Microsoft.AspNetCore.Mvc;
using Saturno_Backend.Services;
using Saturno_Backend.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace Saturno_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceController : ControllerBase
{

    public readonly ServiceServices _service;
    public ServiceController(ServiceServices service)
    {
        _service = service;
    }

    [HttpGet("getall")]
    public async Task<IEnumerable<Service>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Service>> GetById(int id)
    {
        var service = await _service.GetById(id);

        if (service is null)
        {
            return NotFound();
        }

        return service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Service service)
    {
        var newService = await _service.Create(service);

        return CreatedAtAction(nameof(GetById), new { id = newService.Id }, newService);
    }

    [Authorize]
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, Service service)
    {
        if (id != service.Id)
        {
            return BadRequest();
        }

        var serviceToUpdate = await _service.GetById(id);

        if (serviceToUpdate != null)
        {
            await _service.Update(id, service);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {

        var serviceToDelete = await _service.GetById(id);

        if (serviceToDelete != null)
        {
            await _service.Delete(id);
            return Ok();

        }
        else
        {

            return NotFound();

        }
    }

}
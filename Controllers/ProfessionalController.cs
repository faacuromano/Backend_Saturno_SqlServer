using Microsoft.AspNetCore.Mvc;
using Saturno_Backend.Services;
using Saturno_Backend.Data.Models;
using Saturno_Backend.Data.Dto;
namespace Saturno_Backend.Controllers;
using Microsoft.AspNetCore.Authorization;


[ApiController]
[Route("[controller]")]
public class ProfessionalController : ControllerBase
{
    public readonly ProfessionalServices _service;
    public ProfessionalController(ProfessionalServices professional)
    {
        _service = professional;
    }

    [Authorize]
    [HttpGet("getall")]
    public async Task<IEnumerable<Professional>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("getallDto")]
    public async Task<IEnumerable<ProfessionalDto>> GetDto()
    {
        return await _service.GetAllDto();
    }

    [Authorize]
    [HttpGet("get/{id}")]
    public async Task<ActionResult<Professional>> GetById(int id)
    {
        var professional = await _service.GetById(id);

        if (professional is null)
        {
            return NotFound();
        }

        return professional;
    }

    [HttpGet("getDto/{id}")]
    public async Task<ActionResult<ProfessionalDto>> GetByIdDto(int id)
    {
        var professional = await _service.GetDtoById(id);

        if (professional is null)
        {
            return NotFound(
                new { message = $"El cliente con ID = {id} no existe." });
        }

        return professional;
    }

    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> Create(Professional professional)
    {
        var newProfessional = await _service.Create(professional);

        return CreatedAtAction(nameof(GetById), new { id = newProfessional.Id }, newProfessional);
    }

    [Authorize]
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, Professional professional)
    {
        if (id != professional.Id)
        {
            return BadRequest();
        }

        var professionalToUpdate = await _service.GetById(id);

        if (professionalToUpdate != null)
        {
            await _service.Update(id, professional);

            return NoContent();
        }
        else
        {

            return NotFound();
        }
    }

    [Authorize]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var professionalToDelete = await _service.GetById(id);

        if (professionalToDelete != null)
        {
            await _service.Delete(id);
            return Ok();

        }
        else { return NotFound(); }

    }

}
using Microsoft.AspNetCore.Mvc;
using Saturno_Backend.Services;
using Saturno_Backend.Data.Models;

namespace Saturno_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase {

    public readonly ClientService _service;
    public ClientController(ClientService client)
    {
        _service = client;
    }

    [HttpGet]
    public async Task<IEnumerable<Client>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetById(int id)
    {
        var client = await _service.GetById(id);
        
        if(client is null)
        {
            return NotFound(
                new { message = $"El cliente con ID = {id} no existe." });
        }

       return client;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
        var newClient = await _service.Create(client);

        return CreatedAtAction(nameof(GetById), new {id = newClient.Id}, newClient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({client.Id}) de la Body Request." });
        }
         
         var clientToUpdate = await _service.GetById(id);

         if(clientToUpdate != null)
         {
            await _service.Update(id, client);
            return NoContent();
         }
         else{return NotFound(); }
    }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

         var clientToDelete = await _service.GetById(id);

         if(clientToDelete != null)
         {
            await _service.Delete(id);
            return Ok();

         } else{ return NotFound(); } 

        }

}
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
    public IEnumerable<Client> Get()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Client> GetById(int id)
    {
        var client = _service.GetById(id);
        
        if(client is null)
        {
            return NotFound();
        }

       return client;
    }

    [HttpPost]
    public IActionResult Create(Client client)
    {
        var newClient = _service.Create(client);

        return CreatedAtAction(nameof(GetById), new {id = newClient.Id}, newClient);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }
         
         var clientToUpdate = _service.GetById(id);

         if(clientToUpdate != null)
         {
            _service.Update(id, client);
            return NoContent();
         }else{
            return NotFound();
         }
    }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

         var clientToDelete = _service.GetById(id);

         if(clientToDelete != null)
         {
            _service.Delete(id);
            return Ok();

         }else{

            return NotFound();           
         } 
        }

}
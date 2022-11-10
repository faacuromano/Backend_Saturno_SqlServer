using Microsoft.EntityFrameworkCore;
using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;
using Saturno_Backend.Data.Dto;

namespace  Saturno_Backend.Services;

public class ClientService
{
    private readonly SaturnoContext _context;

    public ClientService(SaturnoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<IEnumerable<ClientDto>> GetAllDto()
    {
        return await _context.Clients.Select(t => new ClientDto
        {
            Id = t.Id,
            UserName = t.UserName,
            Name = t.Name,
            PhotoProfile = t.PhotoProfile,

        }).ToListAsync();
    }

     public async Task<Client?> GetById(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<ClientDto?> GetDtoById(int id)
    {
        return await _context.Clients.
        Where(t => t.Id == id).
        Select(t => new ClientDto
        {
            Id = t.Id,
            UserName = t.UserName,
            Name = t.Name,
            PhotoProfile = t.PhotoProfile,
        }).SingleOrDefaultAsync();    
    }


    public async Task<Client> Create(Client newClient)
    {
        _context.Clients.Add(newClient);
        await _context.SaveChangesAsync();
        
        return newClient;
    }

    public async Task Update(int id, Client client)
    {
         
        var existingClient = await GetById(id); 

        if(existingClient != null) 
        { 
            existingClient.Name = client.Name;
            existingClient.UserName = client.UserName;
            existingClient.PhoneNumber = client.PhoneNumber;
            existingClient.Email = client.Email;
            existingClient.Password = client.Password;
            existingClient.PhotoProfile = client.PhotoProfile;

            await _context.SaveChangesAsync();
         }
    }

    public async Task Delete(int id)
    {
        var existingClient = await GetById(id); 

        if(existingClient != null) 
        { 
        _context.Clients.Remove(existingClient);
        await _context.SaveChangesAsync();
        }
    }

}
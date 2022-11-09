using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;

namespace  Saturno_Backend.Services;

public class ClientService
{
    private readonly SaturnoContext _context;

    public ClientService(SaturnoContext context)
    {
        _context = context;
    }

    public IEnumerable<Client> GetAll()
    {
        return _context.Clients.ToList();
    }

     public Client? GetById(int id)
    {
        return _context.Clients.Find(id);
    }

    public Client Create(Client newClient)
    {
        _context.Clients.Add(newClient);
        _context.SaveChanges();
        
        return newClient;
    }

    public void Update(int id, Client client)
    {
         
        var existingClient = GetById(id); 

        if(existingClient != null) 
        { 
            existingClient.Name = client.Name;
            existingClient.UserName = client.UserName;
            existingClient.PhoneNumber = client.PhoneNumber;
            existingClient.Email = client.Email;
            existingClient.Password = client.Password;
            existingClient.PhotoProfile = client.PhotoProfile;

            _context.SaveChanges();
         }
    }

    public void Delete(int id)
    {
        var existingClient = GetById(id); 

        if(existingClient != null) 
        { 
        _context.Clients.Remove(existingClient);
        _context.SaveChanges();
        }
    }

}
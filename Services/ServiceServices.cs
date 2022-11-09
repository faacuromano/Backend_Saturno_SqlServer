using Microsoft.EntityFrameworkCore;
using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;

namespace  Saturno_Backend.Services;

public class ServiceServices
{
    private readonly SaturnoContext _context;

    public ServiceServices(SaturnoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Service>> GetAll()
    {
        return await _context.Services.ToListAsync();
    }

     public async Task<Service?> GetById(int id)
    {
        return await _context.Services.FindAsync(id);
    }

    public async Task<Service> Create(Service newService)
    {
        _context.Services.Add(newService);
        await _context.SaveChangesAsync();
        
        return newService;
    }

    public async Task Update(int id, Service service)
    {
         
        var existingService = await GetById(id); 

        if(existingService != null) 
        { 
            existingService.Id = service.Id;
            existingService.Name = service.Name;
            existingService.Price = service.Price;
            existingService.Description = service.Description;

           await _context.SaveChangesAsync();
         }
    }

    public async Task Delete(int id)
    {
        var existingService = await GetById(id); 

        if(existingService != null) 
        { 
        _context.Services.Remove(existingService);
        await _context.SaveChangesAsync();
        }
    }

}
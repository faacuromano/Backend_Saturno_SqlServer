using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;

namespace  Saturno_Backend.Services;

public class ServiceService
{
    private readonly SaturnoContext _context;

    public ServiceService(SaturnoContext context)
    {
        _context = context;
    }

    public IEnumerable<Service> GetAll()
    {
        return _context.Services.ToList();
    }

     public Service? GetById(int id)
    {
        return _context.Services.Find(id);
    }

    public Service Create(Service newService)
    {
        _context.Services.Add(newService);
        _context.SaveChanges();
        
        return newService;
    }

    public void Update(int id, Service service)
    {
         
        var existingService = GetById(id); 

        if(existingService != null) 
        { 
            existingService.Id = service.Id;
            existingService.Name = service.Name;
            existingService.Price = service.Price;
            existingService.Description = service.Description;

            _context.SaveChanges();
         }
    }

    public void Delete(int id)
    {
        var existingService = GetById(id); 

        if(existingService != null) 
        { 
        _context.Services.Remove(existingService);
        _context.SaveChanges();
        }
    }

}
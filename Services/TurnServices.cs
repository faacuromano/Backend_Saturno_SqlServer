using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;

namespace  Saturno_Backend.Services;

public class TurnServices
{
    private readonly SaturnoContext _context;

    public TurnServices(SaturnoContext context)
    {
        _context = context;
    }

    public IEnumerable<Turn> GetAll()
    {
        return _context.Turns.ToList();
    }

     public Turn? GetById(int id)
    {
        return _context.Turns.Find(id);
    }

    public Turn Create(Turn newTurn)
    {
        _context.Turns.Add(newTurn);
        _context.SaveChanges();
        
        return newTurn;
    }

    public void Update(int id, Turn appointment)
    {
         
        var existingAppointment = GetById(id); 

        if(existingAppointment != null) 
        { 
            existingAppointment.Id = appointment.Id;
            existingAppointment.Name = appointment.Name;
            existingAppointment.Client = appointment.Client;
            existingAppointment.Professional = appointment.Professional;
            existingAppointment.Service = appointment.Service;

            _context.SaveChanges();
         }
    }

    public void Delete(int id)
    {
        var existingAppointment = GetById(id); 

        if(existingAppointment != null) 
        { 
        _context.Turns.Remove(existingAppointment);
        _context.SaveChanges();
        }
    }

}
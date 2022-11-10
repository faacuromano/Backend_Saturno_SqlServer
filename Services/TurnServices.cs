using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Turn>> GetAll()
    {
        return await _context.Turns.ToListAsync();
    }

     public async Task<Turn?> GetById(int id)
    {
        return await _context.Turns.FindAsync(id);
    }

    public async Task<Turn> Create(TurnDTO newTurn)
    {
        var newTurn = new Turn();

        newTurn.Name = newTurnDTO.Name;
        newTurn.ClientId = newTurnDTO.ClientId;
        newTurn.ProfessionalId = newTurnDTO.ProfessionalId;
        newTurn.ServiceId = newTurnDTO.ServiceId;

        _context.Turns.Add(newTurn);
        await _context.SaveChangesAsync();
        
        return newTurn;
    }

    public async Task Update(int id, Turn appointment)
    {
         
        var existingAppointment = await GetById(id); 

        if(existingAppointment != null) 
        { 
            existingAppointment.Id = appointment.Id;
            existingAppointment.Name = appointment.Name;
            existingAppointment.ClientId = appointment.ClientId;
            existingAppointment.ProfessionalId = appointment.ProfessionalId;
            existingAppointment.ServiceId = appointment.ServiceId;

            await _context.SaveChangesAsync();
         }
    }

    public async Task Delete(int id)
    {
        var existingAppointment = await GetById(id); 

        if(existingAppointment != null) 
        { 
        _context.Turns.Remove(existingAppointment);
        await _context.SaveChangesAsync();
        }
    }

}
using Microsoft.EntityFrameworkCore;
using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;
using Saturno_Backend.Data.Dto;

namespace  Saturno_Backend.Services;

public class TurnServices
{
    private readonly SaturnoContext _context;

    public TurnServices(SaturnoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TurnDtoOut>> GetAll()
    {
        return await _context.Turns.Select(t => new TurnDtoOut
        {
            Id = t.Id,
            ProfessionalName = t.ProfessionalNavigation.Name,
            ClientName = t.ClientNavigation.Name,
            ServiceName = t.ServiceNavigation.Name,
            
        }).ToListAsync();
    }

     public async Task<Turn?> GetById(int id)
    {
        return await _context.Turns.FindAsync(id);
    }

    public async Task<Turn> Create(TurnDtoIn newTurnDTO)
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

    public async Task Update(int id, Turn turn)
    {
         
        var existingTurn = await GetById(id); 

        if(existingTurn != null) 
        { 
            existingTurn.Id = turn.Id;
            existingTurn.Name = turn.Name;
            existingTurn.ClientId = turn.ClientId;
            existingTurn.ProfessionalId = turn.ProfessionalId;
            existingTurn.ServiceId = turn.ServiceId;

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
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

    public async Task<Turn> Create(Turn newTurn)
    {
        _context.Turns.Add(newTurn);
        await _context.SaveChangesAsync();
        
        return newTurn;
    }

    public async Task Update(int id, Turn turn)
    {
         
        var  existingTurn = await GetById(id); 

        if(existingTurn != null) 
        { 
            existingTurn.Id = turn.Id;
            existingTurn.Name = turn.Name;
            existingTurn.Client = turn.Client;
            existingTurn.Professional = turn.Professional;
            existingTurn.Service = turn.Service;

            await _context.SaveChangesAsync();
         }
    }

    public async Task Delete(int id)
    {
        var existingTurn = await GetById(id); 

        if(existingTurn != null) 
        { 
        _context.Turns.Remove(existingTurn);
        await _context.SaveChangesAsync();
        }
    }

}
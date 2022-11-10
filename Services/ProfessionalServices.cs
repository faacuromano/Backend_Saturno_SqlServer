using Microsoft.EntityFrameworkCore;
using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;
using Saturno_Backend.Data.Dto;

namespace  Saturno_Backend.Services;

public class ProfessionalServices
{
    private readonly SaturnoContext _context;

    public ProfessionalServices(SaturnoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Professional>> GetAll()
    {
        return await _context.Professionals.ToListAsync();
    }

    public async Task<IEnumerable<ProfessionalDto>> GetAllDto()
    {
        return await _context.Professionals.Select(t => new ProfessionalDto
        {
            Id = t.Id,
            UserName = t.UserName,
            Name = t.Name,
            Description = t.Description,
            Address = t.Address,
            PerfilPhoto = t.PerfilPhoto,
            BannerPhoto = t.BannerPhoto,
            Mail = t.Mail,
            PhoneNumber = t.PhoneNumber,

        }).ToListAsync();
    }

     public async Task<Professional?> GetById(int id)
    {
        return await _context.Professionals.FindAsync(id);
    }

        public async Task<ProfessionalDto?> GetDtoById(int id)
    {
        return await _context.Professionals.
        Where(t => t.Id == id).
        Select(t => new ProfessionalDto
        {
            Id = t.Id,
            UserName = t.UserName,
            Name = t.Name,
            Description = t.Description,
            Address = t.Address,
            PerfilPhoto = t.PerfilPhoto,
            BannerPhoto = t.BannerPhoto,
            Mail = t.Mail,
            PhoneNumber = t.PhoneNumber,
            
        }).SingleOrDefaultAsync();
    }

    public async Task<Professional> Create(Professional newProfessional)
    {
        _context.Professionals.Add(newProfessional);
        await _context.SaveChangesAsync();
        
        return newProfessional;
    }

    public async Task Update(int id, Professional professional)
    {
         
        var existingProfessional = await GetById(id); 

        if(existingProfessional != null) 
        { 
            existingProfessional.UserName = professional.UserName;
            existingProfessional.Password = professional.Password;
            existingProfessional.Name = professional.Name;
            existingProfessional.Mail = professional.Mail;
            existingProfessional.Description  = professional.Description ;
            existingProfessional.PerfilPhoto  = professional.PerfilPhoto ;
            existingProfessional.BannerPhoto   = professional.BannerPhoto  ;
            existingProfessional.PhoneNumber = professional.PhoneNumber;
            existingProfessional.Address = professional.Address;

           await _context.SaveChangesAsync();
         }
    }

    public async Task Delete(int id)
    {
        var existingProfessional = await GetById(id); 

        if(existingProfessional != null) 
        { 
        _context.Professionals.Remove(existingProfessional);
        await _context.SaveChangesAsync();
        }
    }

}
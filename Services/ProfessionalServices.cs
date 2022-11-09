using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;

namespace  Saturno_Backend.Services;

public class ProfessionalServices
{
    private readonly SaturnoContext _context;

    public ProfessionalServices(SaturnoContext context)
    {
        _context = context;
    }

    public IEnumerable<Professional> GetAll()
    {
        return _context.Professionals.ToList();
    }

     public Professional? GetById(int id)
    {
        return _context.Professionals.Find(id);
    }

    public Professional Create(Professional newProfessional)
    {
        _context.Professionals.Add(newProfessional);
        _context.SaveChanges();
        
        return newProfessional;
    }

    public void Update(int id, Professional professional)
    {
         
        var existingProfessional = GetById(id); 

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

            _context.SaveChanges();
         }
    }

    public void Delete(int id)
    {
        var existingProfessional = GetById(id); 

        if(existingProfessional != null) 
        { 
        _context.Professionals.Remove(existingProfessional);
        _context.SaveChanges();
        }
    }

}
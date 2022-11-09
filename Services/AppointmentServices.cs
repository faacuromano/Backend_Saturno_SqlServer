using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;

namespace  Saturno_Backend.Services;

public class AppointmentService
{
    private readonly SaturnoContext _context;

    public AppointmentService(SaturnoContext context)
    {
        _context = context;
    }

    public IEnumerable<Appointment> GetAll()
    {
        return _context.Appointments.ToList();
    }

     public Appointment? GetById(int id)
    {
        return _context.Appointments.Find(id);
    }

    public Appointment Create(Appointment newAppointment)
    {
        _context.Appointments.Add(newAppointment);
        _context.SaveChanges();
        
        return newAppointment;
    }

    public void Update(int id, Appointment appointment)
    {
         
        var existingAppointment = GetById(id); 

        if(existingAppointment != null) 
        { 
            existingAppointment.Id = appointment.Id;
            existingAppointment.Name = appointment.Name;
            existingAppointment.ClientId = appointment.ClientId;
            existingAppointment.ProfessionalId = appointment.ProfessionalId;
            existingAppointment.ServiceId = appointment.ServiceId;
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
        _context.Appointments.Remove(existingAppointment);
        _context.SaveChanges();
        }
    }

}
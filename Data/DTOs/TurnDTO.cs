namespace Saturno_Backend.Data;

public class TurnDTO
{

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int ClientId { get; set; }
    public int ProfessionalId { get; set; }
    public int ServiceId { get; set; }


}
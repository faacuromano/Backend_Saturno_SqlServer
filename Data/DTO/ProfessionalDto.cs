namespace Saturno_Backend.Data.Dto;

public class ProfessionalDto
{
    public int Id { get; set; }

    public string? UserName { get; set; } = null!;

    public string? Name { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public string? Address { get; set; } = null!;

    public string? PerfilPhoto { get; set; } = null!;

    public string? BannerPhoto { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string? Mail { get; set; } 

}
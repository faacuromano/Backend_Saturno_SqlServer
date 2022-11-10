using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Saturno_Backend.Data.Models;

public partial class Turn
{
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = "El nombre debe ser menor a 100 caracteres.")]
    public string Name { get; set; } = null!;

    public int ClientId { get; set; }

    public int ProfessionalId { get; set; }

    public int ServiceId { get; set; }

    [JsonIgnore]
    public virtual Client ClientNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Professional ProfessionalNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Service ServiceNavigation { get; set; } = null!;
}
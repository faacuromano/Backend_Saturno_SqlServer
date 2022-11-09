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
    public virtual Client Client { get; set; } = null!;

    [JsonIgnore]
    public virtual Professional Professional { get; set; } = null!;

    [JsonIgnore]
    public virtual Service Service { get; set; } = null!;
}
    
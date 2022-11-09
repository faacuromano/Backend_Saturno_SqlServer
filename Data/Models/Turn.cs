using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saturno_Backend.Data.Models;

public partial class Turn
{
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = "El nombre debe ser menor a 100 caracteres.")]
    public string Name { get; set; } = null!;

    public int ClientId { get; set; }

    public int ProfessionalId { get; set; }

    public int ServiceId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Professional Professional { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}

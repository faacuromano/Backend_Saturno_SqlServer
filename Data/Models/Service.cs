using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saturno_Backend.Data.Models;

public partial class Service
{
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = "El nombre debe ser menor a 100 caracteres.")]
    public string Name { get; set; } = null!;

    public int Price { get; set; }

    [MaxLength(200, ErrorMessage = "La descripción debe ser menor a 200 caracteres.")]
    public string Description { get; set; } = null!;

    public virtual ICollection<Turn> Turns { get; } = new List<Turn>();
}

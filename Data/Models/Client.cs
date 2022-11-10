using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Saturno_Backend.Data.Dto;

namespace Saturno_Backend.Data.Models;

public partial class Client
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string? UserName { get; set; }

    [MaxLength(100)]
    public string? Password { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;
    
    [MaxLength(400)]
    public string? PhotoProfile { get; set; }

    [MaxLength(400)]
    public virtual ICollection<Turn> Turns { get; } = new List<Turn>();
}
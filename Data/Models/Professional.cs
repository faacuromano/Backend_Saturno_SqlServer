using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Saturno_Backend.Data.Models;

public partial class Professional
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string UserName { get; set; } = null!;

    [MaxLength(100)]
    public string Password { get; set; } = null!;

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [EmailAddress]
    public string Mail { get; set; } = null!;

    [MaxLength(100)]
    public string Description { get; set; } = null!;

    [MaxLength(100)]
    public string Address { get; set; } = null!;

    [MaxLength(100)]
    public string PerfilPhoto { get; set; } = null!;

    [MaxLength(100)]
    public string BannerPhoto { get; set; } = null!;

    [MaxLength(100)]
    public int PhoneNumber { get; set; }

    public virtual ICollection<Turn> Turns { get; } = new List<Turn>();
}
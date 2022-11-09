using System;
using System.Collections.Generic;

namespace Saturno_Backend.Data.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? PhotoProfile { get; set; }

    public virtual ICollection<Turn> Turns { get; } = new List<Turn>();
}

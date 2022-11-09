using System;
using System.Collections.Generic;

namespace Saturno_Backend.Data.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string Description { get; set; } = null!;

    public virtual List<Turn> Turns { get; } = new List<Turn>();
}

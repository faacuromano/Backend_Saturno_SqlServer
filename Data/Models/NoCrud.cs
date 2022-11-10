using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Saturno_Backend.Data.Dto;

namespace Saturno_Backend.Data.Models;

public partial class NoCrud
{
    public int Id { get; set; }
    public string? Description { get; set; }

}
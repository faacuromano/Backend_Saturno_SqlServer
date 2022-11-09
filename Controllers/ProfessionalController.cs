using Microsoft.AspNetCore.Mvc;
using Saturno_Backend.Services;
using Saturno_Backend.Data.Models;

namespace Saturno_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfessionalController : ControllerBase 
{
    public readonly ProfessionalService _service;
    public ProfessionalController(ProfessionalService professional)
    {
        _service = professional;
    }


}
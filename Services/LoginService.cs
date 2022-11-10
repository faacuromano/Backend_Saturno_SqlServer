using Microsoft.EntityFrameworkCore;
using Saturno_Backend.Data;
using Saturno_Backend.Data.Models;
using Saturno_Backend.Data.Dto;

namespace Saturno_Backend.Services;

public class LoginService
{
    private readonly SaturnoContext _context;
    public LoginService(SaturnoContext context)
    {
        _context = context;
    }

    public async Task<Administrator?> GetAdmin(AdminDto admin)
    {
        return await _context.Administrators.SingleOrDefaultAsync(x => x.Email == admin.Email && x.Password == admin.Password);
    }
}
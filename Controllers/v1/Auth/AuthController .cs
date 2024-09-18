using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PROYECTO_NEMURA.DataBase;
using PROYECTO_NEMURA.DTOS;
using PROYECTO_NEMURA.Models;

namespace PROYECTO_NEMURA.Controllers.v1.Auth;

[ApiController]
[Route("api/v1/Auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly string _secretKey;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<User>();
        _secretKey = Environment.GetEnvironmentVariable("KEY_JWT");
    }

    [HttpPost("LoginUser")]
    public async Task<IActionResult> LoginrUser(UserDTOLogin login)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.NickName == login.NickName );
        if (user == null)
        {
            return NotFound("Datos incorrectos");

        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, login.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            return NotFound("datos incorrectos");
        }

        var token = GenerateJwtToken(user);

        return Ok(new{Token =token});

    }

    private string  GenerateJwtToken(User user)
    {
        var claims = new[]
         {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.NickName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    
}
}

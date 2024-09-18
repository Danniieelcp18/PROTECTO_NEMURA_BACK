using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<User>();
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
        return Ok(user);

    }




}

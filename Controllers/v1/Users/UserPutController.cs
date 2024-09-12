using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_NEMURA.DataBase;
using PROYECTO_NEMURA.DTOS;
using PROYECTO_NEMURA.Models;

namespace PROYECTO_NEMURA.Controllers.v1.Users;

[ApiController]
[Route("api/v1/Users")]
public class UserPutController : ControllerBase
{
    private readonly ApplicationDbContext _contex;
    public UserPutController(ApplicationDbContext context)
    {
        _contex = context;
    }
    [HttpPut("EditUser")]
    public async Task<IActionResult> EditUser(int id, [FromBody] UserDtoEdit user)
    {
        var idFound = await _contex.Users.FindAsync(id);

        if (idFound == null)
        {
            return NotFound("Usuario no existe");
        }

        idFound.Name = user.Name;
        idFound.LastName = user.LastName;
        idFound.NickName = user.NickName;
        idFound.Email= user.Email;

        await _contex.SaveChangesAsync();


        return Ok("usuario editado correctamente");
    }

}

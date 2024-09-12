using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_NEMURA.DataBase;

namespace PROYECTO_NEMURA.Controllers.v1.Users;

[ApiController]
[Route("api/v1/Users")]
public class DeleteUserController : ControllerBase
{
    private readonly ApplicationDbContext _contex;
    public DeleteUserController(ApplicationDbContext context)
    {
        _contex = context;
    }
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleteU = await _contex.Users.FindAsync(id);
        
        if (deleteU == null)
        {
            return NotFound("Usuario no encontrado");
        }
        _contex.Users.Remove(deleteU);
        await _contex.SaveChangesAsync();
        return Ok("usuario eliminado correctametne");

    }

}

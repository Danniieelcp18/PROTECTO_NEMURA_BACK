
using Microsoft.AspNetCore.Mvc;
using PROYECTO_NEMURA.DataBase;
using PROYECTO_NEMURA.DTOS;


namespace PROYECTO_NEMURA.Controllers.v1.Users;

[ApiController]
[Route("api/v1/Users")]
public class UserPatchController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public UserPatchController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPatch("EditNameUser")]
    public async Task<IActionResult> EditNameUser(int id, [FromBody] UserDtoName editName)
    {
        var idFound = await _context.Users.FindAsync(id);
        if (idFound == null)
        {
            return NotFound("Usuario no existe");
        }
        idFound.Name = editName.Name;

        await _context.SaveChangesAsync();
        return Ok("Nombre editado correctamente");
    }

    [HttpPatch("EditLastNameUser")]
    public async Task<IActionResult> EditLastName(int id, [FromBody] UserDtoLastName editLastName)
    {
        var idFound = await _context.Users.FindAsync(id);
        if (idFound == null)
        {
            return NotFound("Usuario no exite");
        }
        idFound.LastName = editLastName.LastName;
        await _context.SaveChangesAsync();
        return Ok("Apellido editado correctamente");
    }

    [HttpPatch("EditEmailUser")]
    public async Task<IActionResult> EditEmail(int id, [FromBody] UserDtoEmail editEmail)
    {
        var idFound = await _context.Users.FindAsync(id);
        if (idFound == null)
        {
            return NotFound("Usuario no exite");
        }
        idFound.Email = editEmail.Email;
        await _context.SaveChangesAsync();
        return Ok("Correo editado correctamente");
    }
    [HttpPatch("EditNickNameUser")]
    public async Task<IActionResult> EditNickName(int id, UserDtoNickName editNickName)
    {
        var idFound = await _context.Users.FindAsync(id);
        if (idFound == null)
        {
            return NotFound("Usuario no exite");
        }
        idFound.NickName = editNickName.NickName;
        await _context.SaveChangesAsync();
        return Ok("Apellido editado correctamente");

    }
    [HttpPatch("EditPassword")]
    public async Task<IActionResult> EditPassword(int id, UserDtoPassword editpassword)
    {
        var idFound = await _context.Users.FindAsync(id);
        if (idFound == null)
        {
            return NotFound("Usuario no exite");
        }
        idFound.Password = editpassword.Password;
        await _context.SaveChangesAsync();
        return Ok("Contraseña editada correctamente");

    }


}

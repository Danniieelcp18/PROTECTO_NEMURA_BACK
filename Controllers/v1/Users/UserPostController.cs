using Microsoft.AspNetCore.Mvc;
using PROYECTO_NEMURA.DataBase;
using Microsoft.EntityFrameworkCore;
using PROYECTO_NEMURA.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;


namespace PROYECTO_NEMURA.Controllers.v1.Users;

[ApiController]
[Route("api/v1/User")]

public class UserPostController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public UserPostController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser(User user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("Se registro exitosamente");

        }
        
        return NotFound();

    }

    [HttpPost("CreatePrejet")]
    public async Task<IActionResult> CreateProject(Project project)
    {
        if (ModelState.IsValid)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return Ok("Se creo el proyecto correctamente");

        }
        return NotFound();

    }
    
    
    }

 


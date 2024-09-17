using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_NEMURA.DataBase;
using PROYECTO_NEMURA.Models;

namespace PROYECTO_NEMURA.Controllers.v1.Projects;

[ApiController]
[Route("api/v1/Projects")]
public class AssigmentPostController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AssigmentPostController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("CreateAssigment")]

    public async Task<IActionResult> CreateAssigment([FromBody]Assignment assignment)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            return Ok("Se creó el proyecto correctamente");
        }
        catch (Exception )
        {
        
            return StatusCode(500, $"Error al crear el proyecto la infromacion no es valida, revisa todos los campos");
        }

       
    }
}

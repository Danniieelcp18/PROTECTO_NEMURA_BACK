using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_NEMURA.DataBase;

namespace PROYECTO_NEMURA.Controllers.v1.Projects;

[ApiController]
[Route("api/v1/Projects")]
public class GetAssignmentController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public GetAssignmentController(ApplicationDbContext context)
    {
        _context=context;
    }
    [HttpGet("Assignment")]

    public async Task<IActionResult> GetAll (int projectId)
    {
        var getIdProject = await _context.Assignments.Where (p => p.ProjectId== projectId).ToListAsync();

        if ( getIdProject == null || !getIdProject.Any())
        {
            return NotFound("No se encotraron tareas asociadas a ese proyecto");
        }
        return Ok (getIdProject);
    }

    [HttpGet("GetAssignmentByid")]
    
    public async Task<IActionResult>GetById(int id)
    {
        var getId = await _context.Assignments.FindAsync(id);
        if (getId== null)
        {
            return NotFound("Tarea no encontrada");
        }
        return Ok (getId);
    }
    [HttpGet("GetAssignmentByName")]

    public async Task<IActionResult> GetByNme(string name)
    {
        var getName = await _context.Assignments.FindAsync(name);
        if (getName == null)
        {
            return NotFound("Tarea no encontrada");
        }
        return Ok(getName);
    }


}

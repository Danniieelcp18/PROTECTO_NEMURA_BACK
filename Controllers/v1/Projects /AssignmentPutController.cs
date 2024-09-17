using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_NEMURA.DataBase;
using PROYECTO_NEMURA.DTOS.ProjectsDto;

namespace PROYECTO_NEMURA.Controllers.v1.Projects;

[ApiController]
[Route("api/v1/Projects")]
public class AssignmentPutController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AssignmentPutController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPut("EditAssingment")]

    public async Task<IActionResult> EditAssingment(int id, [FromBody] AssignmentDtoEditAll assignmentEdit)
    {
        var idFound = await _context.Assignments.FindAsync(id);

        if (idFound == null)

        {
            return NotFound("Tarea no encontrada");
        }
        
        idFound.NameAssignemt = assignmentEdit.NameAssignemt;
        idFound.Description= assignmentEdit.Description;
        idFound.Statustype= assignmentEdit.Statustype;
        idFound.PriorityType= assignmentEdit.PriorityType;

        await _context.SaveChangesAsync();
        return Ok("Tarea editada correctamente");

    }




}

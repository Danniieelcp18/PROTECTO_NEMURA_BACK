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
public class AssignmentPatchController : ControllerBase
{
    private readonly ApplicationDbContext _contex;
    public AssignmentPatchController(ApplicationDbContext context)
    {
        _contex = context;
    }
    [HttpPatch("EditName")]
    public async Task<IActionResult> EditName(int id, [FromBody] AssignmentDtoEditName dtoEditName)
    {
        var idFound = await _contex.Assignments.FindAsync(id);
        if (idFound == null)
        {
            return NotFound("Usuario no existe");
        }
        idFound.NameAssignemt = dtoEditName.NameAssignemt;

        await _contex.SaveChangesAsync();
        return Ok("Nombre editado correctamente");

    }
    [HttpPatch("EditDescriotion")]
    public async Task<IActionResult> EditDescription(int id, [FromBody] AssignmentDtoEditDescription dtoEditDescription)
    {
        var idFound = await _contex.Assignments.FindAsync(id);
        if (idFound == null)
        {
            return NotFound("Usuario no existe");
        }
        idFound.Description = dtoEditDescription.Description;

        await _contex.SaveChangesAsync();
        return Ok("Descripcion editada correctamente");

    }
    [HttpPatch("EditStatus")]
    public async Task<IActionResult> Editstatus(int id, [FromBody] AssignmentDtoEditStatusType statusType)
    {
        var idFound = await _contex.Assignments.FindAsync(id);
        if (idFound == null)
        {
            return NotFound("Usuario no existe");
        }
        idFound.Statustype = statusType.Statustype;

        await _contex.SaveChangesAsync();
        return Ok("Estado editado correctamente");

    }
    [HttpPatch("EditPriority")]
    public async Task<IActionResult> EditPriority(int id, [FromBody] AssignmentDtoEditPrioritytype priorityType)
    {
        var idFound = await _contex.Assignments.FindAsync(id);
        if (idFound == null)
        {
            return NotFound("Usuario no existe");
        }
        idFound.PriorityType = priorityType.PriorityType;

        await _contex.SaveChangesAsync();
        return Ok("Prioridad  editada correctamente");

    }



}

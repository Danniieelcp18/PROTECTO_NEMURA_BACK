using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_NEMURA.DataBase;

namespace PROYECTO_NEMURA.Controllers.v1.Projects;

    [ApiController]
    [Route("api/v1/Projects")]
    public class DeleteAssignmentController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public DeleteAssignmentController(ApplicationDbContext context)
        {
            _context=context;
        }

        [HttpDelete("DeleteAssignment")]

        public async Task<IActionResult>DeleteAssignment (int id)
        {
            var deleteAssignment = await _context.Assignments.FindAsync(id);
            if (deleteAssignment==null)
            {
                return NotFound("Tarea no encontrada");

            }
            _context.Assignments.Remove(deleteAssignment);
            await _context.SaveChangesAsync();
            return Ok("Tarea eliminada correctamente");
        }
        
    }

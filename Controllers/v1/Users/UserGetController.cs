using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_NEMURA.DataBase;
using PROYECTO_NEMURA.Models;

namespace PROYECTO_NEMURA.Controllers.v1.Users;

    [ApiController]
    [Route("api/v1/Users")]
    public class UserGetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserGetController (ApplicationDbContext context)
        {
            _context=context;
        }

        [HttpGet("GetUser")]

        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _context.Users.FindAsync(id);

            if (getId == null)
            {
                return NotFound("Usuario no encontrado");
            }
            return Ok (getId);
        }

        [HttpGet ("Getproject")]

        public async Task<IActionResult>GetProject(int id)
        {
            var getId = await _context.Projects.FindAsync(id);
            if (getId == null)
            {
                return NotFound("proyecto no encotrado ");
            }

            return Ok(getId);
        }

        [HttpGet ("GetAllProjects")]

        public async Task<IActionResult> GetAllProjects(int userId)
        {
            var getId = await _context.Projects.Where(u => u.UserId== userId).ToListAsync();

            if ( getId == null || !getId.Any())
            {
                return NotFound("No se encotraron projectos asociados a ese Usuario ");
            }
            return Ok(getId);
        }
    }

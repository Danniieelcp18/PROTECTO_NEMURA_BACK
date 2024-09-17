using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PROYECTO_NEMURA.Models.Assignment;

namespace PROYECTO_NEMURA.DTOS.ProjectsDto;
    public class AssignmentDtoEditAll
    {
    public  string? NameAssignemt { get; set; }
    public  string? Description { get; set; }
   

   
    public  E_Statustype Statustype { get; set; }
    public  EPriorityType PriorityType { get; set; }


}

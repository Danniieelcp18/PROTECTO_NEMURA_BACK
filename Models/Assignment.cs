using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_NEMURA.Models;

public class Assignment 

{
    [Key]
    public required int IdAssignment { get; set; }
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos {1} caracter")]
    [MaxLength(120, ErrorMessage = "El nombre debe tener como maximo {1} caracter ")]


    public required string NameAssignemt { get; set; }
    [MinLength(3, ErrorMessage = "La descripcion debe tener al menos {1} caracter")]
    [MaxLength(250, ErrorMessage = "La description debe tener como maximo {1} caracter ")]
    public required string Description { get; set; }
    public required int ProjectId {get;set;}

    public required E_Statustype Statustype { get; set; }
    public required EPriorityType PriorityType { get; set; }


    public enum E_Statustype
    {
        ToDo,
        InProgress,
        Done
    }
    public enum EPriorityType
    {
        Low,
        High,
        Medium

    }

    [ForeignKey("ProjectId")]
    public Project? Project { get; set; }

}

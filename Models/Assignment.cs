using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PROYECTO_NEMURA.Enums;

namespace PROYECTO_NEMURA.Models;

public class Assignment 

{
    [Key]
    public  int IdAssignment { get; set; }
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos {1} caracter")]
    [MaxLength(255, ErrorMessage = "El nombre debe tener como maximo {1} caracter ")]


    public required string NameAssignemt { get; set; }
    [MinLength(3, ErrorMessage = "La descripcion debe tener al menos {1} caracter")]
    [MaxLength(255, ErrorMessage = "La description debe tener como maximo {1} caracter ")]
    public required string Description { get; set; }
    public required int ProjectId {get;set;}

    [ForeignKey("ProjectId")]


    [JsonIgnore]
    public Project? Project { get; set; }

    [NotMapped]
    public string StatustypeString => Statustype.GetDescription();

    [NotMapped]
    public string PriorityTypeString => PriorityType.GetDescription();


    public required E_Statustype Statustype { get; set; }
    public required EPriorityType PriorityType { get; set; }


    public enum E_Statustype
    {
        [Description("por hacer")]
        ToDo = 0,
        [Description("En Progreso")]
        InProgress = 1,
        [Description("Hecho")]
        Done = 2
    }   
    public enum EPriorityType
    {
        [Description("Baja")]
        Low = 0,
        [Description("Media")]
         High = 1,
        [Description("Alta")]
        Medium = 2

    }

    
    

}

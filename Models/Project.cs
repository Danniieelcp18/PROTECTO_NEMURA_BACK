using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_NEMURA.Models;

public class Project 
{
    [Key]
    public required int IdProject { get; set; }

    [MinLength(3, ErrorMessage = "El nombre debe tener al menos {1} caracter")]
    [MaxLength(120, ErrorMessage = "El nombre debe tener como maximo {1} caracter ")]
    public required string NameProject { get; set; }
    public required int UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User{get;set;}
}

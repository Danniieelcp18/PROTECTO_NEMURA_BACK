using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_NEMURA.DTOS;

    public class UserDtoEdit
    {
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos {1} caracter")]
    [MaxLength(255, ErrorMessage = "El nombre debe tener como maximo {1} caracter ")]
    public required string Name { get; set; }

    [MinLength(3, ErrorMessage = "El apelllido debe tener al menos {1} caracter")]
    [MaxLength(255, ErrorMessage = "El apellido debe tener como maximo {1} caracter ")]
    public required string LastName { get; set; }

    [MinLength(3, ErrorMessage = "El nick name debe tener al menos {1} caracter")]
    [MaxLength(255, ErrorMessage = "El nick  name debe tener como maximo {1} caracter ")]
    public required string NickName { get; set; }

    [EmailAddress(ErrorMessage = "El campo de correo electrónico utiliza un formato no válido")]
    [MinLength(5, ErrorMessage = "El campo de correo electrónico debe tener al menos {1} carácter")]
    [MaxLength(255, ErrorMessage = "El campo de correo electrónico debe tener como máximo {1} carácter")]
    public required string Email { get; set; }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_NEMURA.DTOS;

    public class UserDTOLogin
    {

    [MinLength(3, ErrorMessage = "El nick name debe tener al menos {1} caracter")]
    [MaxLength(255, ErrorMessage = "El nick  name debe tener como maximo {1} caracter ")]
    public required string NickName { get; set; }
    public required string Password { get; set; }

}

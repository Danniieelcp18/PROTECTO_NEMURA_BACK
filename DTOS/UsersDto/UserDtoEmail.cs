using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_NEMURA.DTOS;

    public class UserDtoEmail
    {

        [EmailAddress(ErrorMessage = "El campo de correo electrónico utiliza un formato no válido")]
        [MinLength(5, ErrorMessage = "El campo de correo electrónico debe tener al menos {1} carácter")]
        [MaxLength(255, ErrorMessage = "El campo de correo electrónico debe tener como máximo {1} carácter")]
        public required string Email { get; set; }
    }

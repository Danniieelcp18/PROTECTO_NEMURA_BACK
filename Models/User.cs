using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_NEMURA.Models;

public class User
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string LastName {get;set;}
    public required string NickName {get;set;}
    public required string Email { get; set; }
    public required string Password { get; set; }

}

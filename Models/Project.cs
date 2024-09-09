using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_NEMURA.Models;

    public class Project:User
    {
        public required  int IdProject {get;set;}
        public required string NameProject {get;set;}
    }

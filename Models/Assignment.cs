using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_NEMURA.Models;

    public class Assignment:Project

    { public required int IdAssignment {get;set;}
    public required string NameAssignemt {get;set;}
    public required string Description {get;set;}

    public required E_Statustype Statustype {get;set;}
    public required EPriorityType PriorityType {get;set;}

    
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
        
    }

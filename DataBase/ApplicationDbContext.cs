using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROYECTO_NEMURA.Models;

namespace PROYECTO_NEMURA.DataBase;

    public class ApplicationDbContext:DbContext
    {
        public  DbSet<User> Users {get;set;}
        public DbSet<Project>Projects {get;set;}
        public DbSet <Assignment> Assignments {get;set;}
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext>options): base (options){}
    }

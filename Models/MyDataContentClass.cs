//include this libraries of nuget packages for the project
using Microsoft.EntityFrameworkCore;
//.............
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstProject.Models
{
    public class MyDataContentClass : DbContext //inherits from DbContext of entity framework core.
    {
        //Creamos el constructor y aqui accedemos a una propiedad del entity framwork llamada DbContextOptions al
        //cual le inyectaremos nuestra clase que hereda de la clase principal DbContext.
        public MyDataContentClass(DbContextOptions<MyDataContentClass> options):base(options)
        {
        }
        //Luego de haber creado nuestras entidades o modelos, procedemos a setearlos o configurarlos en una propiedad
        //del entity framwork llamada DbSet...como atributos de propiead de la clase MyDataContextClss..
        DbSet<Estudiante> Estudiante { get; set; }
        DbSet<Maestro> Maestro { get; set; }
        DbSet<Carreras> Carreras { get; set; }
        DbSet<Escuela> Escuela { get; set; }

    }

    //Estass son entidades o modelos utilizados como prueba para demostrar que funciona nuestro CodeFirst project...
    public class Estudiante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    public class Maestro
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    }
    public class Carreras
    {
        public int Id { get; set; }
        public string NameOfCareer { get; set; }
        public string Catetory { get; set; }
    }

    public class Escuela
    {
        public int Id { get; set; }
        public string NombreEscuela { get; set; }
    }
}


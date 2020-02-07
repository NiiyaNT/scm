using System;
using System.ComponentModel.DataAnnotations;
namespace Scm.Domain{
    public class Empleado{
        [Key]
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public string NumeroContacto { get; set; }
    }
}
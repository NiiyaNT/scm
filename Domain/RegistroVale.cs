using System.Collections;
using System;
using System.Collections.Generic;

namespace Scm.Domain{
    public class RegistroVale
    {
        public int IdRegistroVale { get; set; }
        public DateTime Fecha  { get; set; }
        public decimal TotalVale { get; set; }
        public Empleado Empleado { get; set; }
        public List<Vale> Vales { get; set; }
        public AppUser Usuario {get; set;}
        public int IdEmpleado { get; set; }
        public string UsuarioId { get; set; }
    }
}
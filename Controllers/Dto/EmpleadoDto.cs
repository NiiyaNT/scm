using System;
using System.ComponentModel.DataAnnotations;
namespace Scm.Controllers.Dtos{
    public class EmpleadoDto{
        [MaxLength(200)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Tipo{ get; set; }
        [Required]
        public string NumeroContacto { get; set; }
    }
}
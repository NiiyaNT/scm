using System;
using System.ComponentModel.DataAnnotations;
namespace Scm.Controllers.Dtos{
    public class ValeDto{
        [MaxLength(200)]
        [Required]
        public string FolioVale { get; set; } 
        [Required]
        public decimal Monto { get; set; } 
        [Required]
        public decimal FechaExpedicionVale { get; set; } 
        [Required]
        public string Empresa { get; set; }
        [Required]
        public int RegistroValeIdRegistroVale { get; set; }


    }
}
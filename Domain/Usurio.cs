using System;
namespace CargaDescarga{
    public class Usuario{
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int NumIntentos { get; set; }
        public int Status{ get; set; }
    }
}
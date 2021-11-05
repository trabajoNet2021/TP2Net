using System;

namespace Business.Entities
{
    public class Persona: BusinessEntity
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int IdPlan { get; set; }
        public int Legajo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }   
        public string TipoPersona { get; set; }


    }
}

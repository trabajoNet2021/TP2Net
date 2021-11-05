

namespace Business.Entities
{
    public class AlumnoInscripcion:BusinessEntity
    {
        public string Condicion { get; set; }
        public int IdAlumno { get; set; }
        public int IdCurso { get; set; }
        public int Nota { get; set; }

        //Propiedad que sirve para mapear el nombre en la tabla de Alumnos_inscripciones
        public string Nombre { get; set; }

        //Propiedad que sirve para mapear el nombre en la tabla de Alumnos_inscripciones
        public string Apellido { get; set; }


    }
}

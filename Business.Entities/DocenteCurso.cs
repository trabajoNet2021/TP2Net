

namespace Business.Entities
{
    public class DocenteCurso: BusinessEntity
    {
        public int IdCurso { get; set; }

        public int IdDocente { get; set; }

        public string Cargo { get; set; }

        public int IdDictado { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Curso { get; set; }
    }
}

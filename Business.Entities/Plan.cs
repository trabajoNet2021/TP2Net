

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {

        public string Descripcion { get; set; }

        public int IdEspecialidad { get; set; }

        //Esta propiedad será usada para realizar INNER JOIN's con la tabla de Especialidades
        public string DescripcionEspecialidad { get; set; }
    }
}

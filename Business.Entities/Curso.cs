

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        public int AnioCalendario { get; set; }

        public int Cupo { get; set; }

        public int IdComision { get; set; }

        public int IdMateria { get; set; }

        public string Descripcion { get; set; }

        //Propiedad para obtener la materia y mostrarla en Web
        public string Materia { get; set; }

        //Propiedad para obtener la comisión y mostrarla en Web
        public string Comision { get; set; }


    }
}

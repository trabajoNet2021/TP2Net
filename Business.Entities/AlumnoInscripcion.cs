using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class AlumnoInscripcion : BusinessEntity
    {
        string condicion;
        int idAlumno;
        int idCurso;
        int nota;


        public string _Condicion
        {
            get { return condicion; }
            set { condicion = value; }
        }

        public int _IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        public int _IdCurso
        {
            get { return idCurso; }
            set { idCurso = value; }
        }

        public int _Nota
        {
            get { return nota; }
            set { nota = value; }
        }


    }
}

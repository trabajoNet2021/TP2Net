using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        int _idUsuario;
        int _idModulo;
        bool _permiteAlta;
        bool _permiteBaja;
        bool _permiteModificacion;
        bool _permiteConsulta;


        public int _IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int _IdModulo
        {
            get { return _idModulo; }
            set { _idModulo = value; }
        }

        public bool _PermiteAlta
        {
            get { return _permiteAlta; }
            set { _permiteAlta = value; }
        }

        public bool _PermiteBaja
        {
            get { return _permiteBaja; }
            set { _permiteBaja = value; }
        }


        public bool _PermiteModificacion
        {
            get { return _permiteModificacion; }
            set { _permiteModificacion = value; }
        }

        public bool _PermiteConsulta
        {
            get { return _permiteConsulta; }
            set { _permiteConsulta = value; }
        }

    }
}

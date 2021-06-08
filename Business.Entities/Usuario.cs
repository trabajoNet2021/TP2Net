using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        string _nombreUsuario;
        string _clave;
        string _apellido;
        string _nombre;
        string _email;
        bool _habilitado;

        public string _NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string _Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        public string _Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string _Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string _Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool _Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }



    }
}

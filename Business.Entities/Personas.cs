using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Personas: BusinessEntity
    {
        string apellido;
        string nombre;
        string direccion;
        string email;
        string telefono;
        int idPlan;
        int legajo;
        DateTime fechaNacimiento;
        //TiposPersonas tipoPersona;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class SecurityForm : Form
    {

        //Este formulario fue creado para ser heredado por las clases que necesiten implementar
        //sus métodos
        public SecurityForm()
        {
            InitializeComponent();
        }

        public virtual void OcultaAcciones(string tipoPersona)
        {

        }

    }
}

using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {


        public ApplicationForm()
        {
            InitializeComponent();
        }


        public ModoForm Modo { get; set; }

        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion
        }


        #region métodos
        public virtual void MapearDeDatos()
        {

        }

        public virtual void MapearADatos()
        {

        }

        public virtual void GuardarCambios()
        {

        }

        public virtual bool Validar() { return true; }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }


        #endregion

    }
}

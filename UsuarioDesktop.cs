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
    public partial class UsuarioDesktop : ApplicationForm
    {

        Business.Entities.Usuario usuarioActual;



        //Este constructor servirá para las altas
        public UsuarioDesktop(ModoForm modo):this()
        {
            _modo = modo;
        }


        public UsuarioDesktop(int id, ModoForm modo) : this()
        {
            _modo = modo;
            Business.Logic.UsuarioLogic usuarioLogic = new Business.Logic.UsuarioLogic();
            usuarioActual = usuarioLogic.GetOne(id);
            this.MapearDeDatos();
        }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }


        public override void MapearDeDatos()
        {
            this.txtIdUsuario.Text = this.usuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.usuarioActual._Habilitado;
            this.txtNombre.Text = this.usuarioActual._Nombre;
            this.txtApellido.Text = this.usuarioActual._Apellido;
            this.txtEmail.Text = this.usuarioActual._Email;
            this.txtIdUsuario.Text = this.usuarioActual._NombreUsuario;
            this.txtClave.Text = this.usuarioActual._Clave;

            if(_modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
            }

            else if(_modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            else
            {
            }


        }


        public override void MapearADatos()
        {
            if (_modo == ModoForm.Alta)
            {
                usuarioActual = new Business.Entities.Usuario();
                this.usuarioActual._Apellido = this.txtApellido.Text;
                this.usuarioActual._Nombre = this.txtNombre.Text;
                this.usuarioActual._NombreUsuario = this.txtUsuario.Text;
                this.usuarioActual._Email = this.txtEmail.Text;
                this.usuarioActual._Clave = this.txtClave.Text;
                this.usuarioActual.State = Business.Entities.BusinessEntity.States.New;
            }

            else if(_modo == ModoForm.Modificacion)
            {
                this.usuarioActual._Apellido = this.txtApellido.Text;
                this.usuarioActual._Nombre = this.txtNombre.Text;
                this.usuarioActual._NombreUsuario = this.txtUsuario.Text;
                this.usuarioActual._Email = this.txtEmail.Text;
                this.usuarioActual._Clave = this.txtClave.Text;
                this.usuarioActual.State = Business.Entities.BusinessEntity.States.Modified;
            }






        }



        public override void GuardarCambios() { }


        public override bool Validar() { return false; }

        /*
        public override void Notificar(string titulo, string mensaje, MessageBoxButtons, botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        */


        
        /*
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        */
        













        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        //Botón aceptar posee este método
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void tbxIdUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

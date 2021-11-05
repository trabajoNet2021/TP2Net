using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class PersonasDesktop : ApplicationForm
    {

        #region Propiedades
        public Persona PersonaActual { get; set; }
        public PersonaLogic PersonaValida { get; set; }


        #endregion


        #region Constructores

        public PersonasDesktop()
        {
            InitializeComponent();
        }


        public PersonasDesktop(ModoForm modo) : this()
        {
            base.Modo = modo;
        }



        public PersonasDesktop(int id, ModoForm modo) : this()
        {
            base.Modo = modo;
            PersonaValida = new PersonaLogic();
            PersonaActual = PersonaValida.GetOne(id);
            this.MapearDeDatos();
        }


        //Constructor para manejar el tema de la visibilidad
        public PersonasDesktop(ModoForm modo, bool permiso):this()
        {
            this.cboTipoPersona.Text = "Alumno";
            this.cboTipoPersona.Visible = permiso;
            this.lblTipoPersona.Visible = permiso;
            this.txtIdPlan.Visible = permiso;
            this.lblIdPlan.Visible = permiso;
            this.chkHabilitado.Enabled = permiso;
        }


        #endregion


        #region Métodos


        public override void MapearDeDatos()
        {

            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }


            this.txtIdPersona.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();
            this.chkHabilitado.Checked = this.PersonaActual.Habilitado;
            this.txtIdPlan.Text = this.PersonaActual.IdPlan.ToString();
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtNombreUsuario.Text = this.PersonaActual.NombreUsuario;
            this.cboTipoPersona.Text = this.PersonaActual.TipoPersona;

        }

        public override void MapearADatos()
        {

            
            PersonaActual = new Persona();

            this.PersonaActual.Nombre = this.txtNombre.Text;
            this.PersonaActual.Apellido = this.txtApellido.Text;
            this.PersonaActual.Direccion = this.txtDireccion.Text;
            this.PersonaActual.Email = this.txtEmail.Text;
            this.PersonaActual.Telefono = this.txtTelefono.Text;
            this.PersonaActual.FechaNacimiento = DateTime.Parse(this.txtFechaNacimiento.Text);
            this.PersonaActual.Habilitado = this.chkHabilitado.Checked;

            if(!txtIdPlan.Text.Equals(""))
            {
                this.PersonaActual.IdPlan = int.Parse(this.txtIdPlan.Text);
            }
            this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
            this.PersonaActual.Clave = this.txtClave.Text;
            this.PersonaActual.NombreUsuario = this.txtNombreUsuario.Text;
            this.PersonaActual.TipoPersona = this.cboTipoPersona.Text;
        }

        public override void GuardarCambios()
        {
            PersonaValida = new PersonaLogic();

            switch(this.Modo)
            {
                case ModoForm.Alta:
                    this.MapearADatos();
                    PersonaValida.Save(PersonaActual);
                    break;

                case ModoForm.Modificacion:
                    this.MapearADatos();
                    PersonaValida.Save(PersonaActual);
                    break;

                case ModoForm.Baja:
                    PersonaValida.Save(PersonaActual);
                    break;

            }

        }

        public override bool Validar()
        {

            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(this.txtNombre.Text) && !Validaciones.IsFieldEmpty(this.txtApellido.Text) && !Validaciones.IsFieldEmpty(this.txtDireccion.Text) && !Validaciones.IsFieldEmpty(this.txtEmail.Text) && !Validaciones.IsFieldEmpty(this.txtTelefono.Text) && !Validaciones.IsFieldEmpty(this.txtFechaNacimiento.Text) && !Validaciones.IsFieldEmpty(this.txtIdPlan.Text) && !Validaciones.IsFieldEmpty(this.txtLegajo.Text) && !Validaciones.IsFieldEmpty(this.txtClave.Text) && !Validaciones.IsFieldEmpty(this.txtRepetirClave.Text) && !Validaciones.IsFieldEmpty(this.txtNombreUsuario.Text) && !Validaciones.IsFieldEmpty(this.cboTipoPersona.Text))
            {
                this.Notificar("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return bandera;
            }

            if (!Validaciones.IsFieldEmpty(this.txtNombre.Text))
            {
                this.Notificar("Debe completar el campo nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }


            if (!Validaciones.IsFieldEmpty(this.txtApellido.Text))
            {
                this.Notificar("Debe completar el campo apellido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtDireccion.Text))
            {
                this.Notificar("Debe completar el campo dirección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtTelefono.Text))
            {
                this.Notificar("Debe completar el campo teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtFechaNacimiento.Text))
            {
                this.Notificar("Debe completar el campo fecha de nacimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtIdPlan.Text))
            {
                this.Notificar("Debe completar el campo id plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtLegajo.Text))
            {
                this.Notificar("Debe completar el campo legajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if(!Validaciones.ValidaNumero(this.txtLegajo.Text))
            {
                this.Notificar("Legajo", "Debe ingresar un número válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }


            if (!Validaciones.IsFieldEmpty(this.txtClave.Text))
            {
                this.Notificar("Debe completar el campo clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            else
            {
                if (this.txtClave.Text.Length < 8)
                {
                    this.Notificar("La clave debe poseer un mínimo de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bandera = false;

                }

            }

            if (!Validaciones.IsFieldEmpty(this.txtRepetirClave.Text))
            {
                this.Notificar("Debe completar el campo confirmar clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            else
            {
                if (!this.txtClave.Text.Equals(this.txtRepetirClave.Text))
                {
                    this.Notificar("Las contraseñas no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bandera = false;
                }
            }




            //Parte del email
            if (!Validaciones.IsFieldEmpty(this.txtEmail.Text))
            {
                this.Notificar("Debe completar el campo email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            else
            {
                if (Validaciones.IsMailValue(this.txtEmail.Text))
                {

                }

                else
                {
                    this.Notificar("Email incorrecto, falta el símbolo @", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bandera = false;
                }
            }

            if (!Validaciones.IsFieldEmpty(this.txtNombreUsuario.Text))
            {
                this.Notificar("Debe completar el campo nombre de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            if (!Validaciones.IsFieldEmpty(this.cboTipoPersona.Text))
            {
                this.Notificar("Debe completar el campo nombre de tipo persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            return bandera;
        }


        #endregion


        #region Eventos

        private void PersonasDesktop_Load(object sender, EventArgs e)
        {

            switch(this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de persona";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de persona";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de persona";
                    break;

            }
        }

        #endregion


        #region Botones

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            bool bandera;

            switch(this.Modo)
            {


                case ModoForm.Alta:
                    bandera = this.Validar();

                    if (bandera)
                    {
                        this.GuardarCambios();
                        this.Notificar("Alta de persona", "Persona agregada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                    else
                    {
                        this.Notificar("Alta de persona", "La persona no pudo ser agregada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;




                case ModoForm.Modificacion:
                    this.DialogResult = MessageBox.Show("¿Desea modificar la persona seleccionada?", "Modificación de persona", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (this.DialogResult == DialogResult.Yes)
                    {
                        bandera = this.Validar();

                        if (bandera)
                        {
                            this.PersonaActual.State = BusinessEntity.States.Modified;
                            this.GuardarCambios();
                            this.Notificar("Modificación de persona", "Persona actualizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }

                        else
                        {
                            this.Notificar("Modificación de persona", "La persona no pudo ser actualizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;



                case ModoForm.Baja:
                    this.DialogResult = MessageBox.Show("¿Desea borrar la persona seleccionada?", "Baja de persona", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (this.DialogResult == DialogResult.Yes)
                    {
                        this.GuardarCambios();
                        this.Notificar("Baja de persona", "Persona eliminada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    break;

            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        #endregion
    }
}

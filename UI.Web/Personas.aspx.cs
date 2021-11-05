using System;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Personas : ApplicationWebForm
    {

        #region Propiedades
        public PersonaLogic PersonaValida { get; set; }



        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }


        //Propiedad para almacenar la entidad que se está editando
        private Persona Entity { get; set; }

        #endregion


        #region Métodos

        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = this.PersonaValida.GetAll();
                this.gridView.DataBind();
            }

            catch(Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }
            
        }

        protected override void LoadForm(int id)
        {
            try
            {
                this.Entity = this.PersonaValida.GetOne(id);
                this.idPersonaTextBox.Text = this.Entity.ID.ToString();
                this.nombreTextBox.Text = this.Entity.Nombre;
                this.apellidoTextBox.Text = this.Entity.Apellido;
                this.direccionTextBox.Text = this.Entity.Direccion;
                this.emailTextBox.Text = this.Entity.Email;
                this.telefonoTextBox.Text = this.Entity.Telefono;
                this.fechaNacimientoTextBox.Text = this.Entity.FechaNacimiento.ToString();
                this.legajoTextBox.Text = this.Entity.Legajo.ToString();
                this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
                this.idPlanTextBox.Text = this.Entity.IdPlan.ToString();
                this.tipoPersonaDropDownList.Text = this.Entity.TipoPersona;
                this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }

        }

        private void LoadEntity(Persona per)
        {
            per.Nombre = this.nombreTextBox.Text;
            per.Apellido = this.apellidoTextBox.Text;
            per.Direccion = this.direccionTextBox.Text;
            per.Telefono = this.telefonoTextBox.Text;
            per.FechaNacimiento = DateTime.Parse(this.fechaNacimientoTextBox.Text);
            per.Email = this.emailTextBox.Text;
            per.Legajo = int.Parse(this.legajoTextBox.Text);
            per.NombreUsuario = this.nombreUsuarioTextBox.Text;
            
            if(!this.idPlanTextBox.Text.Equals(""))
            {
                per.IdPlan = int.Parse(this.idPlanTextBox.Text);
            }

            per.TipoPersona = this.tipoPersonaDropDownList.Text;
            per.Clave = this.claveTextBox.Text;
            per.Habilitado = this.habilitadoCheckBox.Checked;
        }

        private void SaveEntity(Persona per)
        {
            this.PersonaValida.Save(per);
        }

        protected override void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.fechaNacimientoTextBox.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.idPlanTextBox.Enabled = enable;
            this.tipoPersonaDropDownList.Enabled = enable;
            this.habilitadoCheckBox.Enabled = enable;

        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.PersonaValida.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }

            
        }

        protected override void CleanForm()
        {
            this.idPersonaTextBox.Text = string.Empty;
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.fechaNacimientoTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.idPlanTextBox.Text = string.Empty;
            this.claveTextBox.Text = string.Empty;
            this.repetirClaveTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
        }

        protected override void OcultaValidaciones()
        {
            this.nombreTextBoxValidator.Enabled = false;
            this.apellidoTextBoxValidator.Enabled = false;
            this.direccionTextBoxValidator.Enabled = false;
            this.emailTextBoxValidator.Enabled = false;
            this.telefonoTextBoxValidator.Enabled = false;
            this.fechaNacimientoTextBoxValidator.Enabled = false;
            this.nombreUsuarioTextBoxValidator.Enabled = false;
            this.claveTextBoxValidator.Enabled = false;
            this.repetirClaveTextBoxValidator.Enabled = false;
        }

        protected override void HabilitaValidaciones()
        {
            this.nombreTextBoxValidator.Enabled = true;
            this.apellidoTextBoxValidator.Enabled = true;
            this.direccionTextBoxValidator.Enabled = true;
            this.emailTextBoxValidator.Enabled = true;
            this.telefonoTextBoxValidator.Enabled = true;
            this.fechaNacimientoTextBoxValidator.Enabled = true;
            this.nombreUsuarioTextBoxValidator.Enabled = true;
            this.claveTextBoxValidator.Enabled = true;
            this.repetirClaveTextBoxValidator.Enabled = true;
        }


        //Método que oculta acciones tanto a docentes, como así también a alumnos
        protected override void OcultaAcciones(string tipoPersona)
        {
            //Dentro de este método, se llamará a otro método que oculta los botones
            //que solo un administrador puede ver

            switch (tipoPersona)
            {
                case "Alumno":
                    this.OcultaBotones();
                    break;

                case "Docente":
                    this.OcultaBotones();
                    break;

                default:

                    break;
            }
        }

        protected override void OcultaBotones()
        {
            this.gridPanel.Visible = false;
            this.gridActionsPanel.Visible = false;
            this.formPanel.Visible = false;
            this.formActionsPanel.Visible = false;
        }


        #endregion


        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.OcultaValidaciones();
            }

            PersonaValida = new PersonaLogic();
            Persona per = (Persona)Session["persona"];
            this.OcultaAcciones(per.TipoPersona);
            this.LoadGrid();
        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.CleanForm();
                    this.EnableForm(true);
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Persona();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.CleanForm();
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Persona();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.CleanForm();
                    this.LoadGrid();
                    break;
            }
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            this.CleanForm();
            this.formPanel.Visible = false;
            this.LoadGrid();
            this.HabilitaValidaciones();
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void nuevoLinkButton_Click1(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.CleanForm();
            this.EnableForm(true);
            this.HabilitaValidaciones();
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            this.HabilitaValidaciones();
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        //Evento para seleccionar obtener el id seleccionado
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        #endregion

    }
}
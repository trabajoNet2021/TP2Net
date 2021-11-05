using System;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Especialidades : ApplicationWebForm
    {

        #region Propiedades

        private Especialidad Entity { get; set; }

        public EspecialidadLogic EspecialidadValida { get; set; }


        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        #endregion


        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.OcultaValidaciones();
            }

            EspecialidadValida = new EspecialidadLogic();
            Persona per = (Persona)Session["persona"];
            this.OcultaAcciones(per.TipoPersona);
            this.LoadGrid();
        }

        protected void nuevaLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.CleanForm();
            this.EnableForm(true);
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
                    this.Entity = new Especialidad();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.CleanForm();
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Especialidad();
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

        //Evento para seleccionar obtener el id seleccionado
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PaginaPrincipal.aspx");
        }

        #endregion


        #region Métodos

        protected override void OcultaValidaciones()
        {
            this.descripcionTextBoxValidator.Enabled = false;
        }

        protected override void HabilitaValidaciones()
        {
            this.descripcionTextBoxValidator.Enabled = true;
        }

        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = this.EspecialidadValida.GetAll();
                this.gridView.DataBind();
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }

        }

        protected override void LoadForm(int id)
        {
            this.Entity = this.EspecialidadValida.GetOne(id);
            this.idEspecialidadTextBox.Text = this.Entity.ID.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion;
        }

        private void LoadEntity(Especialidad esp)
        {
            esp.Descripcion = this.descripcionTextBox.Text;
        }

        private void SaveEntity(Especialidad esp)
        {
            this.EspecialidadValida.Save(esp);
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.EspecialidadValida.Delete(id);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }
            
        }

        protected override void CleanForm()
        {
            this.idEspecialidadTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
        }

        protected override void EnableForm(bool enable)
        {
            this.idEspecialidadTextBox.Enabled = enable;
            this.descripcionTextBox.Enabled = enable;
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
            this.nuevaLinkButton.Visible = false;
            this.editarLinkButton.Visible = false;
            this.eliminarLinkButton.Visible = false;
            this.aceptarButton.Visible = false;
            this.cancelarButton.Visible = false;
            this.gridView.Columns[2].Visible = false;
        }


        #endregion

    }
}
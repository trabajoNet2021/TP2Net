using System;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Cursos : ApplicationWebForm
    {


        #region Propiedades

        public CursoLogic CursoValido { get; set; }

        private Curso Entity { get; set; }


        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }



        #endregion



        #region Métodos

        protected override void OcultaValidaciones()
        {
            this.idMateriaTextBoxValidator.Enabled = false;
            this.idComisionTextBoxValidator.Enabled = false;
            this.anioCalendarioTextBoxValidator.Enabled = false;
            this.cupoTextBoxValidator.Enabled = false;
            this.descripcionTextBoxValidator.Enabled = false;
        }

        protected override void HabilitaValidaciones()
        {
            this.idMateriaTextBoxValidator.Enabled = true;
            this.idComisionTextBoxValidator.Enabled = true;
            this.anioCalendarioTextBoxValidator.Enabled = true;
            this.cupoTextBoxValidator.Enabled = true;
            this.descripcionTextBoxValidator.Enabled = true;
        }

        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = this.CursoValido.GetCursoMateriaCom();
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
                CursoValido = new CursoLogic();
                this.Entity = this.CursoValido.GetOne(id);
                this.idCursoTextBox.Text = this.Entity.ID.ToString();
                this.idMateriaTextBox.Text = this.Entity.IdMateria.ToString();
                this.idComisionTextBox.Text = this.Entity.IdComision.ToString();
                this.anioCalendarioTextBox.Text = this.Entity.AnioCalendario.ToString();
                this.cupoTextBox.Text = this.Entity.Cupo.ToString();
                this.descripcionTextBox.Text = this.Entity.Descripcion;
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }


        }

        private void LoadEntity(Curso crs)
        {
            crs.IdMateria = int.Parse(this.idMateriaTextBox.Text);
            crs.IdComision = int.Parse(this.idComisionTextBox.Text);
            crs.AnioCalendario = int.Parse(this.anioCalendarioTextBox.Text);
            crs.Cupo = int.Parse(this.cupoTextBox.Text);
            crs.Descripcion = this.descripcionTextBox.Text;
        }

        private void SaveEntity(Curso crs)
        {
            this.CursoValido.Save(crs);
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.CursoValido.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }

        }

        protected override void CleanForm()
        {
            this.idCursoTextBox.Text = string.Empty;
            this.idMateriaTextBox.Text = string.Empty;
            this.idComisionTextBox.Text = string.Empty;
            this.anioCalendarioTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
        }

        protected override void EnableForm(bool enable)
        {
            this.idCursoTextBox.Enabled = enable;
            this.idMateriaTextBox.Enabled = enable;
            this.idComisionTextBox.Enabled = enable;
            this.anioCalendarioTextBox.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
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
            this.nuevoLinkButton.Visible = false;
            this.editarLinkButton.Visible = false;
            this.eliminarLinkButton.Visible = false;
            this.aceptarButton.Visible = false;
            this.cancelarButton.Visible = false;
            this.gridView.Columns[6].Visible = false;
        }

        #endregion



        #region Eventos 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.OcultaValidaciones();
            }

            CursoValido = new CursoLogic();
            Persona per = (Persona)Session["persona"];
            this.OcultaAcciones(per.TipoPersona);
            this.LoadGrid();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
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

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.CleanForm();
            this.EnableForm(true);
            this.HabilitaValidaciones();
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
                    this.Entity = new Curso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.CleanForm();
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Curso();
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
            Response.Redirect("/PaginaPrincipal.aspx");
        }

        #endregion

    }
}
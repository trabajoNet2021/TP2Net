using System;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Comisiones : ApplicationWebForm
    {

        #region Propiedades
        private Comision Entity
        {
            get;
            set;
        }

        public ComisionLogic ComisionValida { get; set; }

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

            ComisionValida = new ComisionLogic();
            Persona per = (Persona)Session["persona"];
            this.OcultaAcciones(per.TipoPersona);
            this.LoadGrid();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void nuevaLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.CleanForm();
            this.EnableForm(true);
            this.HabilitaValidaciones();
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
                    this.Entity = new Comision();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.CleanForm();
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;

                case FormModes.Alta:
                    this.Entity = new Comision();
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


        #region Métodos

        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = this.ComisionValida.GetAll();
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
                this.Entity = this.ComisionValida.GetOne(id);
                this.idComisionTextBox.Text = this.Entity.ID.ToString();
                this.descripcionTextBox.Text = this.Entity.Descripcion;
                this.añoEspecialidadTextBox.Text = this.Entity.AnioEspecialidad.ToString();
                this.idPlanTextBox.Text = this.Entity.IdPlan.ToString();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }

        }

        private void LoadEntity(Comision com)
        {
            com.Descripcion = this.descripcionTextBox.Text;
            com.AnioEspecialidad = int.Parse(this.añoEspecialidadTextBox.Text);
            com.IdPlan = int.Parse(this.idPlanTextBox.Text);
        }

        private void SaveEntity(Comision com)
        {
            this.ComisionValida.Save(com);
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.ComisionValida.Delete(id);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }
            
        }

        protected override void CleanForm()
        {
            this.idComisionTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
            this.añoEspecialidadTextBox.Text = string.Empty;
            this.idPlanTextBox.Text = string.Empty;
        }

        protected override void EnableForm(bool enable)
        {
            this.idComisionTextBox.Enabled = enable;
            this.descripcionTextBox.Enabled = enable;
            this.añoEspecialidadTextBox.Enabled = enable;
            this.idPlanTextBox.Enabled = enable;
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
            this.gridView.Columns[4].Visible = false;
        }
        protected override void OcultaValidaciones()
        {
            this.idPlanTextBoxValidator.Enabled = false;
            this.descripcionTextBoxValidator.Enabled = false;
            this.añoEspecialidadTextBoxValidator.Enabled = false;
        }
        protected override void HabilitaValidaciones()
        {
            this.idPlanTextBoxValidator.Enabled = true;
            this.descripcionTextBoxValidator.Enabled = true;
            this.añoEspecialidadTextBoxValidator.Enabled = true;
        }


        #endregion


    }
}
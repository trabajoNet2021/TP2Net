using System;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Planes : ApplicationWebForm
    {

        #region Propiedaes

        public PlanLogic PlanValido { get; set; }
        private Plan Entity { get; set; }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        #endregion



        #region Métodos

        protected override void OcultaValidaciones()
        {
            this.descripcionTextBoxValidator.Enabled = false;
            this.idEspecialidadTextBoxValidator.Enabled = false;
        }

        protected override void HabilitaValidaciones()
        {
            this.descripcionTextBoxValidator.Enabled = true;
            this.idEspecialidadTextBoxValidator.Enabled = true;
        }

        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = this.PlanValido.GetPlanesEspecialidad();
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
            try
            {
                this.Entity = this.PlanValido.GetOne(id);
                this.idPlanTextBox.Text = this.Entity.ID.ToString();
                this.descripcionTextBox.Text = this.Entity.Descripcion;
                this.idEspecialidadTextBox.Text = this.Entity.IdEspecialidad.ToString();
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }

        }

        private void LoadEntity(Plan pln)
        {
            pln.Descripcion = this.descripcionTextBox.Text;
            pln.IdEspecialidad = int.Parse(this.idEspecialidadTextBox.Text);
        }

        protected void SaveEntity(Plan pln)
        {
            this.PlanValido.Save(pln);
        }

        protected override void EnableForm(bool enable)
        {
            this.idPlanTextBox.Enabled = enable;
            this.descripcionTextBox.Enabled = enable;
            this.idEspecialidadTextBox.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.PlanValido.Delete(id);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }
            
        }

        protected override void CleanForm()
        {
            this.idPlanTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
            this.idEspecialidadTextBox.Text = string.Empty;
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
            this.gridView.Columns[3].Visible = false;
        }


        #endregion



        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                this.OcultaValidaciones();
            }

            PlanValido = new PlanLogic();
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
                this.formActionsPanel.Visible = true;
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
                    //Con esto deselecciono la fila que usé
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Plan();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.CleanForm();
                    //Con esto deselecciono la fila que usé
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Plan();
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
        #endregion


    }
}
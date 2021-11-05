using System;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Materias : ApplicationWebForm
    {

        #region Propiedades
        public MateriaLogic MateriaValida { get; set; }


        private Materia Entity { get; set; }


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
            this.hsSemanalesTextBoxValidator.Enabled = false;
            this.hsTotalesTextBoxValidator.Enabled = false;
            this.idPlanTextBoxValidator.Enabled = false;
        }

        protected override void HabilitaValidaciones()
        {
            this.descripcionTextBoxValidator.Enabled = true;
            this.hsSemanalesTextBoxValidator.Enabled = true;
            this.hsTotalesTextBoxValidator.Enabled = true;
            this.idPlanTextBoxValidator.Enabled = true;
        }

        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = this.MateriaValida.GetAll();
                this.gridView.DataBind();
            }

            catch(Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }

        }

        protected override void CleanForm()
        {
            this.idMateriaTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
            this.horasSemanalesTextBox.Text = string.Empty;
            this.hsTotalesTextBox.Text = string.Empty;
            this.idPlanTextBox.Text = string.Empty;
        }

        protected override void LoadForm(int id)
        {
            try
            {
                this.Entity = this.MateriaValida.GetOne(id);
                this.idMateriaTextBox.Text = this.Entity.ID.ToString();
                this.descripcionTextBox.Text = this.Entity.Descripcion;
                this.horasSemanalesTextBox.Text = this.Entity.HorasSemanales.ToString();
                this.hsTotalesTextBox.Text = this.Entity.HorasTotales.ToString();
                this.idPlanTextBox.Text = this.Entity.IdPlan.ToString();
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }

        }

        private void LoadEntity(Materia mtr)
        {
            mtr.Descripcion = this.descripcionTextBox.Text;
            mtr.HorasSemanales = int.Parse(this.horasSemanalesTextBox.Text);
            mtr.HorasTotales = int.Parse(this.hsTotalesTextBox.Text);
            mtr.IdPlan = int.Parse(this.idPlanTextBox.Text);
        }

        private void SaveEntity(Materia mtr)
        {
            this.MateriaValida.Save(mtr);
        }

        protected override void EnableForm(bool enable)
        {
            this.idMateriaTextBox.Enabled = enable;
            this.descripcionTextBox.Enabled = enable;
            this.horasSemanalesTextBox.Enabled = enable;
            this.hsTotalesTextBox.Enabled = enable;
            this.idPlanTextBox.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.MateriaValida.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }
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
            this.gridView.Columns[5].Visible = false;
        }

        #endregion



        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.OcultaValidaciones();
            }

            MateriaValida = new MateriaLogic();
            Persona per = (Persona)Session["persona"];
            this.OcultaAcciones(per.TipoPersona);
            this.LoadGrid();
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
                    this.Entity = new Materia();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.CleanForm();
                    this.LoadGrid();
                    this.gridView.SelectedIndex = -1;
                    break;
                case FormModes.Alta:
                    this.Entity = new Materia();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.CleanForm();
                    this.LoadGrid();
                    break;
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

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            this.CleanForm();
            this.formPanel.Visible = false;
            this.LoadGrid();
            this.HabilitaValidaciones();
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PaginaPrincipal.aspx");
        }

        #endregion


    }
}
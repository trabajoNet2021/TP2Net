using System;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Profesores : ApplicationWebForm
    {

        #region Propiedades

        public ProfesorLogic ProfesorValido { get; set; }

        private DocenteCurso Entity { get; set; }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }


        #endregion


        #region Métodos

        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = this.ProfesorValido.GetProCurPer();
                this.gridView.DataBind();
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }

        }

        protected override void OcultaValidaciones()
        {
            this.idCursoTextBoxValidator.Enabled = false;
            this.idDocenteTextBoxValidator.Enabled = false;
            this.cargoTextBoxValidator.Enabled = false;
        }

        protected override void HabilitaValidaciones()
        {
            this.idCursoTextBoxValidator.Enabled = true;
            this.idDocenteTextBoxValidator.Enabled = true;
            this.cargoTextBoxValidator.Enabled = true;
        }

        protected override void LoadForm(int id)
        {
            try
            {
                this.Entity = this.ProfesorValido.GetOne(id);
                this.idDictadoTextBox.Text = this.Entity.ID.ToString();
                this.idCursoTextBox.Text = this.Entity.IdCurso.ToString();
                this.idDocenteTextBox.Text = this.Entity.IdDocente.ToString();
                this.cargoTextBox.Text = this.Entity.Cargo;
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }


        }

        private void LoadEntity(DocenteCurso pro)
        {
            pro.IdCurso = int.Parse(this.idCursoTextBox.Text);
            pro.IdDocente = int.Parse(this.idDocenteTextBox.Text);
            pro.Cargo = this.cargoTextBox.Text;
        }

        private void SaveEntity(DocenteCurso pro)
        {
            this.ProfesorValido.Save(pro);
        }

        protected override void EnableForm(bool enable)
        {
            this.idCursoTextBox.Enabled = enable;
            this.idDocenteTextBox.Enabled = enable;
            this.cargoTextBox.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.ProfesorValido.Delete(id);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex.Message);
            }
            
        }

        protected override void CleanForm()
        {
            this.idDictadoTextBox.Text = string.Empty;
            this.idCursoTextBox.Text = string.Empty;
            this.idDocenteTextBox.Text = string.Empty;
            this.cargoTextBox.Text = string.Empty;
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
            this.FormActionsPanel.Visible = false;
        }


        #endregion


        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.OcultaValidaciones();
            }

            ProfesorValido = new ProfesorLogic();
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
                    //Con esto deselecciono la fila que usé
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new DocenteCurso();
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
                    this.Entity = new DocenteCurso();
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

        protected void editarLinkButton_Click1(object sender, EventArgs e)
        {
            this.HabilitaValidaciones();
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarLinkButton_Click1(object sender, EventArgs e)
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
            this.FormActionsPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.CleanForm();
            this.EnableForm(true);
            this.HabilitaValidaciones();
        }

        protected void girdView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        #endregion


    }
}
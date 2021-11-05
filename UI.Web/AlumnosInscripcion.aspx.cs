using System;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Alumnos : ApplicationWebForm
    {

        #region Propiedades

        public AlumnoInscripcionLogic AlumnoValido { get; set; }

        //Propiedad para almacenar la entidad que se está editando
        public AlumnoInscripcion Entity { get; set; }


        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        #endregion


        #region Métodos
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


                default:
                    break;
            }

        }

        protected override void OcultaValidaciones()
        {
            this.idAlumnoTextBoxValidator.Enabled = false;
            this.idCursoTextBoxValidator.Enabled = false;
        }

        protected override void HabilitaValidaciones()
        {
            this.idAlumnoTextBoxValidator.Enabled = true;
            this.idCursoTextBoxValidator.Enabled = true;
        }

        protected override void OcultaBotones()
        {
            this.editarLinkButton.Enabled = false;
            this.eliminarLinkButton.Enabled = false;
            this.notaTextBox.Enabled = false;
            this.condicionTextBox.Enabled = false;
            this.gridPanel.Visible = false;
        }

        protected override void LoadForm(int id)
        {
            try
            {
                this.Entity = this.AlumnoValido.GetOne(id);
                this.idInscripcionTextBox.Text = this.Entity.ID.ToString();
                this.idAlumnoTextBox.Text = this.Entity.IdAlumno.ToString();
                this.idCursoTextBox.Text = this.Entity.IdCurso.ToString();
                this.notaTextBox.Text = this.Entity.Nota.ToString();
                this.condicionTextBox.Text = this.Entity.Condicion;
            }

            catch(Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex);
            }
            
        }

        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = AlumnoValido.GetAlumnosPersonas();
                this.gridView.DataBind();
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex);
            }
            
        }

        protected override void CleanForm()
        {
            this.idInscripcionTextBox.Text = string.Empty;
            this.idAlumnoTextBox.Text = string.Empty;
            this.idCursoTextBox.Text = string.Empty;
            this.notaTextBox.Text = string.Empty;
            this.condicionTextBox.Text = string.Empty;
        }

        private void LoadEntity(AlumnoInscripcion alu)
        {

            alu.IdAlumno = int.Parse(this.idAlumnoTextBox.Text);
            alu.IdCurso = int.Parse(this.idCursoTextBox.Text);

            if (!this.notaTextBox.Text.Equals(""))
            {
                alu.Nota = int.Parse(this.notaTextBox.Text);
            }

            alu.Condicion = this.condicionTextBox.Text;
        }

        private void SaveEntity(AlumnoInscripcion alu)
        {
            this.AlumnoValido.Save(alu);
        }

        protected override void EnableForm(bool enable)
        {
            Persona per = (Persona)Session["persona"];
            if (!per.TipoPersona.Equals("Alumno"))
            {
                this.idAlumnoTextBox.Enabled = enable;
                this.idCursoTextBox.Enabled = enable;
                this.notaTextBox.Enabled = enable;
                this.condicionTextBox.Enabled = enable;
            }

            else
            {
                this.idAlumnoTextBox.Enabled = enable;
                this.idCursoTextBox.Enabled = enable;
                this.notaTextBox.Enabled = false;
                this.condicionTextBox.Enabled = false;
            }

        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.AlumnoValido.Delete(id);
            }
            catch(Exception ex)
            {
                Logger.WriteLog(ex.ToString());
                Response.Write(ex);
            }

            
        }

        #endregion


        #region Eventos

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.OcultaValidaciones();
            }

            AlumnoValido = new AlumnoInscripcionLogic();
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

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
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

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            this.OcultaValidaciones();
            this.CleanForm();
            this.formPanel.Visible = false;
            this.LoadGrid();
            this.HabilitaValidaciones();
        }

        protected void acceptaButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    Validaciones.AumentaCupo(this.idCursoTextBox.Text);
                    this.CleanForm();
                    this.gridView.SelectedIndex = -1;
                    this.formPanel.Visible = false;
                    this.formActionsPanel.Visible = false;
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new AlumnoInscripcion();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.CleanForm();
                    this.gridView.SelectedIndex = -1;
                    this.formPanel.Visible = false;
                    this.formActionsPanel.Visible = false;
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new AlumnoInscripcion();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    Validaciones.DisminuyeCupo(this.idCursoTextBox.Text);
                    this.CleanForm();
                    this.LoadGrid();
                    break;
            }

        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PaginaPrincipal.aspx");
        }

        #endregion


    }
}
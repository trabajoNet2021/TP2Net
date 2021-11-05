using System;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Cursos : SecurityForm
    {

        #region Constructores

        public Cursos()
        {
            InitializeComponent();
        }

        public Cursos(Persona per) : this()
        {
            switch(per.TipoPersona)
            {
                case "Alumno":

                    break;
            }
        }

        public Cursos(string tipoAccion) : this()
        {
            switch(tipoAccion)
            {
                case "Modificacion":
                    this.tsbNuevo.Visible = false;
                    this.tsbEliminar.Visible = false;
                    break;

                case "Baja":
                    this.tsbNuevo.Visible = false;
                    this.tsbEditar.Visible = false;
                    break;
            }
        }


        #endregion



        #region Métodos

        public override void OcultaAcciones(string tipoPersona)
        {
            if(tipoPersona.Equals("Alumno"))
            {
                this.tsMenuCursos.Visible = false;
            }
        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dgvCursos.DataSource = cl.GetCursoMateriaCom();
            this.dgvCursos.Columns[0].HeaderText = "Año calendario";
            this.dgvCursos.Columns[2].Visible = false;
            this.dgvCursos.Columns[3].Visible = false;
            this.dgvCursos.Columns[7].HeaderText = "Id de curso";
            this.dgvCursos.Columns[8].Visible = false;
        }


        #endregion



        #region Eventos

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }


        #endregion



        #region Botones

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursosDesktop formCurso = new CursosDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursosDesktop modificar = new CursosDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursosDesktop baja = new CursosDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }

        #endregion





    }
}
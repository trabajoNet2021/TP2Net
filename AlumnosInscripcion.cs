using System;
using System.Windows.Forms;
using Business.Logic;


namespace UI.Desktop
{
    public partial class AlumnosInscripcion : Form
    {

        #region Constructores

        public AlumnosInscripcion()
        {
            InitializeComponent();
        }


        #endregion


        #region Eventos

        private void Alumnos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAlta_Click(object sender, EventArgs e)
        {
            AlumnosDesktop formAlumno = new AlumnosDesktop(ApplicationForm.ModoForm.Alta);
            formAlumno.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnosDesktop modificar = new AlumnosDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnosDesktop baja = new AlumnosDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }



        #endregion


        #region Métodos
        public void Listar()
        {
            AlumnoInscripcionLogic al = new AlumnoInscripcionLogic();
            this.dgvAlumnos.DataSource = al.GetAlumnosPersonas();
            this.dgvAlumnos.Columns[1].HeaderText = "Id de alumno";
            this.dgvAlumnos.Columns[2].HeaderText = "Id de curso";
            this.dgvAlumnos.Columns[6].Visible = false;
            this.dgvAlumnos.Columns[7].Visible = false;
        }

        #endregion

    }
}

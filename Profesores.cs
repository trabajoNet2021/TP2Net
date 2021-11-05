using System;
using System.Windows.Forms;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Profesores : Form
    {
        public Profesores()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Profesores_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            ProfesorLogic pl = new ProfesorLogic();
            this.dgvProfesores.DataSource = pl.GetAll();
            this.dgvProfesores.Columns[0].HeaderText = "Id de curso";
            this.dgvProfesores.Columns[1].HeaderText = "Id de docente";
            this.dgvProfesores.Columns[3].HeaderText = "Id de dictado";

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.DocenteCurso)this.dgvProfesores.SelectedRows[0].DataBoundItem).ID;
            ProfesoresDesktop modificar = new ProfesoresDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ProfesoresDesktop formProfesor = new ProfesoresDesktop(ApplicationForm.ModoForm.Alta);
            formProfesor.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.DocenteCurso)this.dgvProfesores.SelectedRows[0].DataBoundItem).ID;
            ProfesoresDesktop baja = new ProfesoresDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }

    }
}
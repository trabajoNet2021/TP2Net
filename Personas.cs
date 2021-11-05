using System;
using System.Windows.Forms;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Personas : Form
    {

        #region Constructores

        public Personas()
        {
            InitializeComponent();
        }


        #endregion

        #region Métodos
        public void Listar()
        {
            PersonaLogic pLogic = new PersonaLogic();
            this.dgvPersonas.DataSource = pLogic.GetAll();
            this.dgvPersonas.Columns[5].HeaderText = "Id de plan";
            this.dgvPersonas.Columns[7].HeaderText = "Fecha de nacimiento";
            this.dgvPersonas.Columns[13].Visible = false;
        }

        #endregion

        #region Eventos
        private void Personas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        #endregion

        #region Botones
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonasDesktop frmPersonas = new PersonasDesktop(ApplicationForm.ModoForm.Alta);
            frmPersonas.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonasDesktop modificar = new PersonasDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonasDesktop baja = new PersonasDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}

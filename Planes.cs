using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
        }

        public Planes(Persona per) : this()
        {
            switch(per.TipoPersona)
            {
                case "Alumno":
                    this.OcultaFuncionalidades(per.TipoPersona);
                    break;
            }
        }


        public Planes(string tipoAccion) : this()
        {
            switch (tipoAccion)
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

        private void OcultaFuncionalidades(string tipoPersona)
        {
            if(tipoPersona.Equals("Alumno"))
            {
                this.tsMenuPlanes.Visible = false;
            }
        }


        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            PlanLogic p1 = new PlanLogic();
            this.dgvPlanes.DataSource = p1.GetPlanesEspecialidad();
            this.dgvPlanes.Columns[1].Visible = false;
            this.dgvPlanes.Columns[3].HeaderText = "Id de plan";
            this.dgvPlanes.Columns[4].Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbEditarPlan_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop modificar = new PlanDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }

        private void tsbNuevoPlan_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEliminarPlan_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop baja = new PlanDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }


    }
}
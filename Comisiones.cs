using System;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Comisiones : SecurityForm
    {

        #region Constructores

        public Comisiones()
        {
            InitializeComponent();
        }

        public Comisiones(Persona per):this()
        {
            switch(per.TipoPersona)
            {
                case "Alumno":
                    this.OcultaAcciones(per.TipoPersona);
                    break;
            }
        }


        public Comisiones(string tipoAccion) : this()
        {
            switch (tipoAccion)
            {
                case "Modificacion":
                    this.tsbAlta.Visible = false;
                    this.tsbEliminar.Visible = false;
                    break;

                case "Baja":
                    this.tsbAlta.Visible = false;
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
                this.tsMenuComisiones.Visible = false;
            }
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.DataSource = cl.GetAll();
            this.dgvComisiones.Columns[0].HeaderText = "Año especialidad";
            this.dgvComisiones.Columns[1].HeaderText = "Id de plan";
            this.dgvComisiones.Columns[3].HeaderText = "Id de comisión";
            this.dgvComisiones.Columns[4].Visible = false;
        }

        #endregion




        #region Eventos

        private void frmComisiones_Load(object sender, EventArgs e)
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

        private void tsbAlta_Click(object sender, EventArgs e)
        {
            ComisionesDesktop frmComision = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);
            frmComision.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionesDesktop modificar = new ComisionesDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionesDesktop baja = new ComisionesDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }

        #endregion


    }
}

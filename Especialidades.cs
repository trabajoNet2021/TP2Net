using System;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Especialidades : SecurityForm
    {

        #region Constructores
        public Especialidades()
        {
            InitializeComponent();
        }

        public Especialidades(Persona per) : this()
        {
            switch(per.TipoPersona)
            {
                case "Alumno":
                    this.OcultaAcciones(per.TipoPersona);
                    break;

            }
        }


        public Especialidades(string tipoAccion) : this()
        {
            switch (tipoAccion)
            {
                case "Modificacion":
                    this.tsbAlta.Visible = false;
                    this.tsbBaja.Visible = false;
                    break;

                case "Baja":
                    this.tsbAlta.Visible = false;
                    this.tsbModificar.Visible = false;
                    break;
            }
        }

        #endregion



        #region Métodos
        public override void OcultaAcciones(string tipoPersona)
        {
            if(tipoPersona.Equals("Alumno"))
            {
                this.tsMenuEspecialidades.Visible = false;
            }
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
            this.dgvEspecialidades.Columns[1].HeaderText = "Id de especialidad";
            this.dgvEspecialidades.Columns[2].Visible = false;
        }

        #endregion



        #region Eventos

        private void Especialidades_Load(object sender, EventArgs e)
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
            EspecialidadesDesktop formEspecialidad = new EspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }


        private void tsbModificar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadesDesktop modificar = new EspecialidadesDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }




        private void tsbBaja_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadesDesktop baja = new EspecialidadesDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }

        #endregion


    }
}

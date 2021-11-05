using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Materias : Form
    {

        #region Constructores
        public Materias()
        {
            InitializeComponent();
        }

        public Materias(Persona per):this()
        {
            switch(per.TipoPersona)
            {
                case "Alumno":
                    this.OcultaFuncionalidades(per.TipoPersona);
                    break;

                case "Docente":
                    this.OcultaFuncionalidades(per.TipoPersona);
                    break;
            }
        }


        public Materias(string tipoAccion) : this()
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

        #endregion


        #region Métodos

        private void OcultaFuncionalidades(string tipoPersona)
        {
            if(tipoPersona.Equals("Alumno") || tipoPersona.Equals("Docente"))
            {
                this.tsMenuMaterias.Visible = false;
            }
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAll();
            this.dgvMaterias.Columns[1].HeaderText = "Horas semanales";
            this.dgvMaterias.Columns[2].HeaderText = "Horas totales";
            this.dgvMaterias.Columns[3].HeaderText = "Id de plan";
            this.dgvMaterias.Columns[4].HeaderText = "Id de materia";
            this.dgvMaterias.Columns[5].Visible = false;
        }


        #endregion


        #region Eventos


        private void Materias_Load(object sender, EventArgs e)
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop modificar = new MateriaDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop baja = new MateriaDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }

        #endregion

    }
}
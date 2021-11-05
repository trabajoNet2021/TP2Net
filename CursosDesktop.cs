using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class CursosDesktop : ApplicationForm
    {

        #region Propiedades
        public CursoLogic CursoValido { get; set; }
        public Curso CursoActual { get; set; }

        #endregion



        #region Constructores

        public CursosDesktop(ModoForm modo) : this()
        {
            base.Modo = modo;
        }


        public CursosDesktop(int id, ModoForm modo) : this()
        {
            base.Modo = modo;
            CursoValido = new CursoLogic();
            CursoActual = CursoValido.GetOne(id);
            this.MapearDeDatos();
        }


        public CursosDesktop()
        {
            InitializeComponent();
        }


        #endregion

        

        #region Métodos


        public override void MapearDeDatos()
        {

            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            this.txtIDCurso.Text = this.CursoActual.ID.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtIdComision.Text = this.CursoActual.IdComision.ToString();
            this.txtIdMateria.Text = this.CursoActual.IdMateria.ToString();
            this.txtDescripcion.Text = this.CursoActual.Descripcion;

        }



        public override void MapearADatos()
        {

            if (this.Modo == ModoForm.Alta)
            {
                CursoActual = new Curso();
            }

            this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
            this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
            this.CursoActual.IdComision = int.Parse(this.txtIdComision.Text);
            this.CursoActual.IdMateria = int.Parse(this.txtIdMateria.Text);
            this.CursoActual.Descripcion = this.txtDescripcion.Text;

        }


        public override void GuardarCambios()
        {
            CursoValido = new CursoLogic();

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.MapearADatos();
                    CursoValido.Save(CursoActual);
                    break;

                case ModoForm.Modificacion:
                    this.MapearADatos();
                    CursoValido.Save(CursoActual);
                    break;

                case ModoForm.Baja:
                    CursoValido.Save(CursoActual);
                    break;

            }

        }

        public override bool Validar()
        {

            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(this.txtAnioCalendario.Text) && !Validaciones.IsFieldEmpty(this.txtCupo.Text) && !Validaciones.IsFieldEmpty(this.txtIdComision.Text) && !Validaciones.IsFieldEmpty(this.txtIdMateria.Text) && !Validaciones.IsFieldEmpty(this.txtDescripcion.Text))
            {
                this.Notificar("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return bandera;
            }


            if (!Validaciones.IsFieldEmpty(this.txtAnioCalendario.Text))
            {
                this.Notificar("Debe completar el campo de año calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtCupo.Text))
            {
                this.Notificar("Debe completar el campo de cupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtIdComision.Text))
            {
                this.Notificar("Debe completar el campo de ID Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtIdMateria.Text))
            {
                this.Notificar("Debe completar el campo de ID Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtDescripcion.Text))
            {
                this.Notificar("Debe completar el campo de descripcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }
            return bandera;
        }

        #endregion



        #region Eventos

        private void CursosDesktop_Load(object sender, EventArgs e)
        {
            switch(this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de curso";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de curso";
                    break;

                default:
                    this.Text = "Baja de curso";
                    break;
            } 
        }


        #endregion



        #region Botones

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bandera = true;

            switch (Modo)
            {
                case ModoForm.Alta:
                    bandera = this.Validar();
                    if (bandera)
                    {
                        this.GuardarCambios();
                        MessageBox.Show("Curso agregado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("El Curso no pudo ser agregado");
                    }
                    break;


                case ModoForm.Baja:
                    this.CursoActual.State = Business.Entities.BusinessEntity.States.Deleted;
                    this.GuardarCambios();
                    this.Notificar("Baja de Curso", "Curso eliminado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    break;

                case ModoForm.Modificacion:
                    this.CursoActual.State = Business.Entities.BusinessEntity.States.Modified;
                    bandera = this.Validar();
                    if (bandera)
                    {
                        this.GuardarCambios();
                        this.Notificar("Modificación de Curso", "Curso actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                    else
                    {
                        this.Notificar("Modificación de Curso", "El Curso no pudo ser actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
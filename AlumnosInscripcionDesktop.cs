using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AlumnosDesktop : ApplicationForm
    {

        #region Propiedades

        public AlumnoInscripcionLogic AlumnoValido { get; set; }
        public AlumnoInscripcion AlumnoActual { get;set; }

        #endregion


        #region Constructores

        public AlumnosDesktop(ModoForm modo) : this()
        {
            base.Modo = modo;
        }

        public AlumnosDesktop(int id, ModoForm modo):this()
        {
            base.Modo = modo;
            AlumnoValido = new AlumnoInscripcionLogic();
            AlumnoActual = AlumnoValido.GetOne(id);
            this.MapearDeDatos();
        }



        public AlumnosDesktop()
        {
            InitializeComponent();
        }

        #endregion


        #region Métodos

        private void AlumnosDesktop_Load(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.Text = "Alta de alumno";
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                this.Text = "Modificación de alumno";
            }

            else
            {
                this.Text = "Baja de alumno";
            }
        }

        public override void MapearDeDatos()
        {

            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            this.txtIdInscripcion.Text = this.AlumnoActual.ID.ToString();
            this.txtIdAlumno.Text = this.AlumnoActual.IdAlumno.ToString();
            this.txtIdCurso.Text = this.AlumnoActual.IdCurso.ToString();
            this.txtNota.Text = this.AlumnoActual.Nota.ToString();
            this.txtCondicion.Text = this.AlumnoActual.Condicion;

        }

        public override void MapearADatos()
        {
            AlumnoActual = new AlumnoInscripcion();

            if(!this.txtNota.Text.Equals(""))
            {
                this.AlumnoActual.Nota = int.Parse(this.txtNota.Text);
            }

            this.AlumnoActual.Condicion = this.txtCondicion.Text;
            this.AlumnoActual.IdCurso = int.Parse(this.txtIdCurso.Text);
            this.AlumnoActual.IdAlumno = int.Parse(this.txtIdAlumno.Text);
        }

        public override void GuardarCambios()
        {
            AlumnoValido = new AlumnoInscripcionLogic();

            switch(this.Modo)
            {
                case ModoForm.Alta:
                    this.MapearADatos();
                    AlumnoValido.Save(AlumnoActual);
                    break;

                case ModoForm.Modificacion:
                    this.MapearADatos();
                    AlumnoActual.State = BusinessEntity.States.Modified;
                    AlumnoValido.Save(AlumnoActual);
                    break;

                case ModoForm.Baja:
                    Validaciones.AumentaCupo(txtIdCurso.Text);
                    AlumnoValido.Save(AlumnoActual);
                    break;
            }

        }

        public override bool Validar()
        {
            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(this.txtIdAlumno.Text) && !Validaciones.IsFieldEmpty(this.txtIdCurso.Text) && !Validaciones.IsFieldEmpty(this.txtNota.Text) && !Validaciones.IsFieldEmpty(this.txtCondicion.Text))
            {
                this.Notificar("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return bandera;
            }

            if (!Validaciones.IsFieldEmpty(this.txtIdAlumno.Text))
            {
                this.Notificar("Debe completar el campo Id usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtIdCurso.Text))
            {
                this.Notificar("Debe completar el campo Id de curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }


            if (!Validaciones.IsFieldEmpty(this.txtCondicion.Text))
            {
                this.Notificar("Debe completar el campo condición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if(!this.txtNota.Text.Equals(""))
            {
                if (!Validaciones.IsScoreValid(this.txtNota.Text))
                {
                    this.Notificar("La nota debe ser un número entre 1 y 10", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bandera = false;
                }
            }

            return bandera;
        }

        #endregion


        #region Botones

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            bool bandera;

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    bandera = this.Validar();

                    if (bandera)
                    {
                        this.GuardarCambios();
                        Validaciones.DisminuyeCupo(this.txtIdCurso.Text);
                        this.Notificar("Alta de Alumno", "Alumno agregado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                    else
                    {
                        this.Notificar("Alta de Alumno", "El alumno no pudo ser agregado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;


                case ModoForm.Baja:
                    this.AlumnoActual.State = Business.Entities.BusinessEntity.States.Deleted;
                    this.DialogResult = MessageBox.Show("¿Desea borrar el alumno seleccionado?", "Baja de alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (this.DialogResult == DialogResult.Yes)
                    {
                        this.GuardarCambios();
                        this.Notificar("Baja de Alumno", "Alumno eliminado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    break;


                case ModoForm.Modificacion:
                    this.DialogResult = MessageBox.Show("¿Desea modificar el alumno seleccionado?", "Modificación de alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (this.DialogResult == DialogResult.Yes)
                    {
                        bandera = this.Validar();

                        if (bandera)
                        {
                            this.GuardarCambios();
                            this.Notificar("Modificación de Alumno", "Alumno actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }

                        else
                        {
                            this.Notificar("Modificación de Alumno", "El alumno no pudo ser actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }


            this.Close();




        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListadoCursos_Click(object sender, EventArgs e)
        {
            Cursos frmCursos = new Cursos();
            frmCursos.ShowDialog();
        }

        #endregion


    }
}

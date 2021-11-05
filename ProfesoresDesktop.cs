using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class ProfesoresDesktop : ApplicationForm
    {

        public ProfesorLogic ProfesorValido { get; set; }

        public DocenteCurso ProfesorActual { get; set; }


        public ProfesoresDesktop(ModoForm modo) : this()
        {
            base.Modo = modo;
        }


        public ProfesoresDesktop(int id, ModoForm modo) : this()
        {
            base.Modo = modo;
            ProfesorValido = new ProfesorLogic();
            ProfesorActual = ProfesorValido.GetOne(id);
            this.MapearDeDatos();
        }



        public ProfesoresDesktop()
        {
            InitializeComponent();
        }


        public override void MapearDeDatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }

            else if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            this.txtIdDictado.Text = this.ProfesorActual.ID.ToString();
            this.txtIdCurso.Text = this.ProfesorActual.IdCurso.ToString();
            this.txtIdDocente.Text = this.ProfesorActual.IdDocente.ToString();
            this.txtCargo.Text = this.ProfesorActual.Cargo;
        }

        public override void MapearADatos()
        {

            if (this.Modo == ModoForm.Alta)
            {
                ProfesorActual = new DocenteCurso();
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                ProfesorActual.State = BusinessEntity.States.Modified;
            }

            this.ProfesorActual.IdCurso = int.Parse(this.txtIdCurso.Text);
            this.ProfesorActual.IdDocente = int.Parse(this.txtIdDocente.Text);
            this.ProfesorActual.Cargo = this.txtCargo.Text;
        }

        public override void GuardarCambios()
        {
            ProfesorValido = new ProfesorLogic();

            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                ProfesorValido.Save(ProfesorActual);
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                ProfesorValido.Save(ProfesorActual);
            }

            else if (this.Modo == ModoForm.Baja)
            {
                ProfesorValido.Save(ProfesorActual);
            }



        }

        public override bool Validar()
        {
            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(this.txtIdCurso.Text) && !Validaciones.IsFieldEmpty(this.txtIdDocente.Text) && !Validaciones.IsFieldEmpty(this.txtCargo.Text))
            {
                this.Notificar("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return bandera;
            }


            if (!Validaciones.IsFieldEmpty(this.txtIdCurso.Text))
            {
                this.Notificar("Debe completar el campo de ID Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtIdDocente.Text))
            {
                this.Notificar("Debe completar el campo de ID Docente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtCargo.Text))
            {
                this.Notificar("Debe completar el campo de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }


            return bandera;
        }


        private void ProfesoresDesktop_Load(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.Text = "Alta de profesor";
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                this.Text = "Modificación de profesor";
            }

            else
            {
                this.Text = "Baja de profesor";
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {

            bool bandera = true;

            if (this.Modo == ModoForm.Alta)
            {

                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    this.Notificar("Alta de profesor", "Profesor agregado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                else
                {
                    this.Notificar("Alta de profesor", "El profesor no pudo ser agregado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            else if (this.Modo == ModoForm.Baja)
            {
                this.ProfesorActual.State = Business.Entities.BusinessEntity.States.Deleted;
                this.DialogResult = MessageBox.Show("¿Desea borrar el profesor seleccionado?", "Baja de profesor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (this.DialogResult == DialogResult.Yes)
                {
                    this.GuardarCambios();
                    this.Notificar("Baja de profesor", "Profesor eliminado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

            }



            else if (this.Modo == ModoForm.Modificacion)
            {
                this.ProfesorActual.State = Business.Entities.BusinessEntity.States.Modified;
                this.DialogResult = MessageBox.Show("¿Desea modificar el profesor seleccionado?", "Modificación de profesor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (this.DialogResult == DialogResult.Yes)
                {
                    bandera = this.Validar();

                    if (bandera)
                    {
                        this.GuardarCambios();
                        this.Notificar("Modificación de profesor", "Profesor actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                    else
                    {
                        this.Notificar("Modificación de profesor", "El profesor no pudo ser actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }

            this.Close();
        }
    }
}
using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class EspecialidadesDesktop : ApplicationForm
    {

        #region Propiedades
        public EspecialidadLogic EspecialidadValida { get; set; }
        public Especialidad EspecialidadActual { get; set; }

        #endregion


        #region Constructores
        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }


        public EspecialidadesDesktop(ModoForm modo) : this()
        {
            base.Modo = modo;
        }


        public EspecialidadesDesktop(int id, ModoForm modo) : this()
        {
            base.Modo = modo;
            EspecialidadValida = new EspecialidadLogic();
            EspecialidadActual = EspecialidadValida.GetOne(id);
            this.MapearDeDatos();
        }



        #endregion
        

        #region Botones

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


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
                        this.Notificar("Alta de Especialidad", "Especialidad agregada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                    else
                    {
                        this.Notificar("Alta de Especialidad", "La especialidad no pudo ser agregada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;


                case ModoForm.Modificacion:
                    this.EspecialidadActual.State = Business.Entities.BusinessEntity.States.Modified;
                    bandera = this.Validar();

                    if (bandera)
                    {
                        this.GuardarCambios();
                        this.Notificar("Modificación de especialidad", "Especialidad actualizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                    else
                    {
                        this.Notificar("Modificación de especialidad", "La especialidad no pudo ser actualizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case ModoForm.Baja:
                    this.EspecialidadActual.State = Business.Entities.BusinessEntity.States.Deleted;
                    this.GuardarCambios();
                    this.Notificar("Baja de especialidad", "Especialidad eliminada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    break;

            }

            this.Close();
        }


        #endregion


        #region Métodos

        public override void MapearDeDatos()
        {
            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            this.txtIdEspecialidad.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                EspecialidadActual = new Especialidad();
            }

            this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
        }


        public override void GuardarCambios()
        {
            EspecialidadValida = new EspecialidadLogic();

            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                EspecialidadValida.Save(EspecialidadActual);
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                EspecialidadValida.Save(EspecialidadActual);
            }

            else if (this.Modo == ModoForm.Baja)
            {
                EspecialidadValida.Save(EspecialidadActual);
            }


        }

        public override bool Validar()
        {
            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(txtDescripcion.Text))
            {
                this.Notificar("Debe completar el campo descripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }
            return bandera;
        }


        #endregion


        #region Eventos
        private void EspecialidadesDesktop_Load(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.Text = "Alta de especialidad";
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                this.Text = "Modificación de especialidad";
            }

            else
            {
                this.Text = "Baja de especialidad";
            }
        }

        #endregion


    }
}
    
using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {

        #region Propiedades

        public Materia MateriaActual { get; set; }
        public MateriaLogic MateriaValida { get; set; }

        #endregion


        #region Constructores
        public MateriaDesktop(ModoForm modo) : this()
        {
            base.Modo = modo;

        }

        public MateriaDesktop(int id, ModoForm modo) : this()
        {
            base.Modo = modo;
            MateriaValida = new MateriaLogic();
            MateriaActual = MateriaValida.GetOne(id);
            this.MapearDeDatos();
        }



        public MateriaDesktop()
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


            this.txtIDMateria.Text = this.MateriaActual.ID.ToString();
            this.txtDescMateria.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HorasSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HorasTotales.ToString();
            this.txtIDPlan.Text = this.MateriaActual.IdPlan.ToString();
        }

        public override void MapearADatos()
        {

            if (this.Modo == ModoForm.Alta)
            {
                MateriaActual = new Materia();
            }

            this.MateriaActual.HorasSemanales = int.Parse(this.txtHsSemanales.Text);
            this.MateriaActual.Descripcion = this.txtDescMateria.Text;
            this.MateriaActual.HorasTotales = int.Parse(this.txtHsTotales.Text);
            this.MateriaActual.IdPlan = int.Parse(this.txtIDPlan.Text);

        }

        public override void GuardarCambios()
        {
            MateriaValida = new MateriaLogic();

            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                MateriaValida.Save(MateriaActual);
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                MateriaValida.Save(MateriaActual);
            }

            else if (this.Modo == ModoForm.Baja)
            {
                MateriaValida.Save(MateriaActual);
            }



        }

        public override bool Validar()
        {
            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(this.txtDescMateria.Text) && !Validaciones.IsFieldEmpty(this.txtHsSemanales.Text) && !Validaciones.IsFieldEmpty(this.txtHsTotales.Text) && !Validaciones.IsFieldEmpty(this.txtIDPlan.Text))
            {
                this.Notificar("Alta de materia", "Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return bandera;
            }


            if (!Validaciones.IsFieldEmpty(this.txtDescMateria.Text))
            {
                this.Notificar("Alta de materia", "Debe completar el campo de Desc Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtHsSemanales.Text))
            {
                this.Notificar("Alta de materia", "Debe completar el campo de Hs Semanales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtHsTotales.Text))
            {
                this.Notificar("Alta de materia", "Debe completar el campo de Hs Totales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtIDPlan.Text))
            {
                this.Notificar("Alta de materia", "Debe completar el campo de ID Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            return bandera;
        }

        #endregion


        #region Eventos

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de materia";
                    break;
                case ModoForm.Modificacion:
                    this.Text = "Modificación de materia";
                    break;
                case ModoForm.Baja:
                    this.Text = "Baja de materia";
                    break;
            }
        }

        #endregion


        #region Botones

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Alta)
            {
                bool bandera = true;
                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    this.Notificar("Alta de materia", "Materia agregada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                else
                {
                    this.Notificar("Alta de materia", "La materia no pudo ser agregada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            else if (this.Modo == ModoForm.Baja)
            {
                this.MateriaActual.State = Business.Entities.BusinessEntity.States.Deleted;
                this.GuardarCambios();
            }



            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.State = Business.Entities.BusinessEntity.States.Modified;
                this.GuardarCambios();
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
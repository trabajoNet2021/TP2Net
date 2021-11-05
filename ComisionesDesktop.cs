using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class ComisionesDesktop : ApplicationForm
    {

        #region Propiedades
        public Comision ComisionActual { get; set; }

        
        public ComisionLogic ComisionValida { get; set; }

        #endregion



        #region Constructores
        public ComisionesDesktop()
        {
            InitializeComponent();
        }


        public ComisionesDesktop(ModoForm modo) : this()
        {
            base.Modo = modo;
        }

        public ComisionesDesktop(int id, ModoForm modo) : this()
        {
            base.Modo = modo;
            ComisionValida = new ComisionLogic();
            ComisionActual = ComisionValida.GetOne(id);
            this.MapearDeDatos();
        }

        #endregion



        #region Métodos



        public override void MapearDeDatos()
        {

            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            this.txtIdComision.Text = this.ComisionActual.ID.ToString();
            this.txtIdPlan.Text = this.ComisionActual.IdPlan.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAñoEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();

        }


        public override void MapearADatos()
        {

            if (this.Modo == ModoForm.Alta)
            {
                ComisionActual = new Comision();
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                ComisionActual.State = BusinessEntity.States.Modified;
            }

            this.ComisionActual.IdPlan = int.Parse(this.txtIdPlan.Text);
            this.ComisionActual.Descripcion = this.txtDescripcion.Text;
            this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAñoEspecialidad.Text);

        }


        public override void GuardarCambios()
        {
            ComisionValida = new ComisionLogic();

            switch(this.Modo)
            {
                case ModoForm.Alta:
                    this.MapearADatos();
                    ComisionValida.Save(ComisionActual);
                    break;


                case ModoForm.Modificacion:
                    this.MapearADatos();
                    ComisionValida.Save(ComisionActual);
                    break;

                case ModoForm.Baja:
                    ComisionValida.Save(ComisionActual);
                    break;

            }

        }


        public override bool Validar()
        {

            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(this.txtIdPlan.Text) && !Validaciones.IsFieldEmpty(this.txtDescripcion.Text) && !Validaciones.IsFieldEmpty(this.txtAñoEspecialidad.Text))
            {
                this.Notificar("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return bandera;
            }


            if (!Validaciones.IsFieldEmpty(this.txtIdPlan.Text))
            {
                this.Notificar("Debe completar el campo Id de plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtDescripcion.Text))
            {
                this.Notificar("Debe completar el campo descripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtAñoEspecialidad.Text))
            {
                this.Notificar("Debe completar el campo nombre de año de especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            return bandera;
        }

        
        private void ComisionesDesktop_Load(object sender, EventArgs e)
        {
            switch(this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de comisión";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de comisión";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de comisión";
                    break;
            }

        }



        #endregion



        #region Botones

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            bool bandera;

            switch(this.Modo)
            {
                case ModoForm.Alta:
                    bandera = this.Validar();

                    if (bandera)
                    {
                        this.GuardarCambios();
                        this.Notificar("Alta de comisión", "Comisión agregada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                    else
                    {
                        this.Notificar("Alta de comisión", "La comisión no pudo ser agregada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;


                case ModoForm.Modificacion:
                    this.ComisionActual.State = Business.Entities.BusinessEntity.States.Modified;
                    this.DialogResult = MessageBox.Show("¿Desea modificar la comisión seleccionada?", "Modificación de comisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (this.DialogResult == DialogResult.Yes)
                    {
                        bandera = this.Validar();

                        if (bandera)
                        {
                            this.GuardarCambios();
                            this.Notificar("Modificación de comisión", "Comisión actualizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }

                        else
                        {
                            this.Notificar("Modificación de comisión", "La comisión no pudo ser actualizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;

                case ModoForm.Baja:
                    this.ComisionActual.State = Business.Entities.BusinessEntity.States.Deleted;
                    this.DialogResult = MessageBox.Show("¿Desea borrar la comisión seleccionada?", "Baja de comisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (this.DialogResult == DialogResult.Yes)
                    {
                        this.GuardarCambios();
                        this.Notificar("Baja de comisión", "Comisión eliminada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
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

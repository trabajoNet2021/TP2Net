using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        Plan planActual;
        PlanLogic planValido;

        public Plan PlanActual
        {
            get { return planActual; }
            set { planActual = value; }
        }



        public PlanDesktop(ModoForm modo) : this()
        {
            base.Modo = modo;

        }



        public PlanDesktop(int id, ModoForm modo) : this()
        {
            base.Modo = modo;
            planValido = new PlanLogic();
            PlanActual = planValido.GetOne(id);
            this.MapearDeDatos();
        }




        public PlanDesktop()
        {
            InitializeComponent();
        }


        public override void MapearDeDatos()
        {
            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }


            this.txtIDPlan.Text = this.PlanActual.ID.ToString();
            this.txtIDEspecialidad.Text = this.PlanActual.IdEspecialidad.ToString();
            this.txtDescPlan.Text = this.PlanActual.Descripcion;
        }

        public override void MapearADatos()
        {

            if (this.Modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
            }


            this.PlanActual.IdEspecialidad = int.Parse(this.txtIDEspecialidad.Text);
            this.PlanActual.Descripcion = this.txtDescPlan.Text;

        }


        public override void GuardarCambios()
        {
            planValido = new PlanLogic();

            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                planValido.Save(PlanActual);
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                planValido.Save(PlanActual);
            }

            else if (this.Modo == ModoForm.Baja)
            {
                planValido.Save(PlanActual);
            }



        }


        public override bool Validar()
        {
            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(this.txtIDEspecialidad.Text) && !Validaciones.IsFieldEmpty(this.txtDescPlan.Text))
            {
                this.Notificar("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return bandera;
            }


            if (!Validaciones.IsFieldEmpty(this.txtIDEspecialidad.Text))
            {
                this.Notificar("Debe completar el campo de ID Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtDescPlan.Text))
            {
                this.Notificar("Debe completar el campo de descripcion del plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }


            return bandera;
        }



        private void PlanDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Alta)
            {
                bool bandera = true;
                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    MessageBox.Show("Plan agregado correctamente");
                }

                else
                {
                    MessageBox.Show("El plan no pudo ser agregado");
                }
            }



            else if (this.Modo == ModoForm.Baja)
            {
                this.PlanActual.State = Business.Entities.BusinessEntity.States.Deleted;
                this.GuardarCambios();
            }



            else if (this.Modo == ModoForm.Modificacion)
            {
                this.PlanActual.State = Business.Entities.BusinessEntity.States.Modified;
                this.GuardarCambios();
            }

            this.Close();
        }

        private void PlanDesktop_Load_1(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.Text = "Alta de Plan";
            }

            else if (this.Modo == ModoForm.Modificacion)
            {
                this.Text = "Modificación de Plan";
            }

            else
            {
                this.Text = "Baja de Plan";
            }
        }
    }
}
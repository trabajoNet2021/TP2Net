using System.Windows.Forms;
using Business.Logic;
using Business.Entities;




namespace UI.Desktop
{


    //Formulario básico del cual heredarán todos los formularios para altas, bajas y modificaciones
    public partial class ApplicationForm
    {

        public ModoForm _modo;

        public ModoForm Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }

        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

        /*MapearDeDatos va a ser utilizado en cada formulario para copiar la
         * información de las entidades a los controles del formulario(TextBox, ComboBox, etc) 
         * para mostrar la infromación de cada entidad*/
        public virtual void MapearDeDatos() { }

        /*MapearADatos se va a utilizar para pasar la información de los 
         * controles a una entidad para luego enviarla a las capas inferiores*/
        public virtual void MapearADatos() { }

        /*GuardarCambios es el método que se encargará de invocar al método
         * correspondiente de la capa de negocio según sea el ModoForm en que se
         * encuentre el formulario*/

        public virtual void GuardarCambios() { }


        /*GuardarCambios es el método que se encargará de invocar al método
         * correspondiente de la capa de negocio según sea el ModoForm en que se
        encuentre el formulario*/

        public virtual bool Validar() { return false; }

        /*
        public void Notificar(string titulo, string mensaje, MessageBoxButtons, botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }


        */


        /*Notificar es el método que utilizaremos para unificar el mecanismo de 
         * avisos al usuario y en caso de tener que modificar la forma en que se 
        realizan los avisos al usuario sólo se debe modificar este método, en 
        lugar de tener que reemplazarlo en toda la aplicación.*/


        /*

        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }


        */






        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        




        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ApplicationForm";
            this.Text = "ApplicationForm";
            this.Load += new System.EventHandler(this.ApplicationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
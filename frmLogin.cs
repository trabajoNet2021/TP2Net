using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class frmLogin : Form
    {

        #region Constructores
        public frmLogin()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos

        private Persona Existe(string user, string pass)
        {
            Persona per;
            PersonaLogic pl = new PersonaLogic();
            per = pl.GetByUser(user, pass);
            return per;
        }

        private void Limpiar()
        {
            this.txtUsuario.Text = string.Empty;
            this.txtContraseña.Text = string.Empty;
        }

        #endregion

        #region Botones


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Persona per;
            per = Existe(this.txtUsuario.Text, this.txtContraseña.Text);

            this.txtUsuario.Text = string.Empty;
            this.txtContraseña.Text = string.Empty;

            if (per != null)
            {
                frmMain mainForm;

                switch (per.TipoPersona)
                {
                    case "Admin":
                        mainForm = new frmMain(per);
                        mainForm.ShowDialog();
                        break;

                    case "Alumno":
                        mainForm = new frmMain(per);
                        mainForm.ShowDialog();
                        break;

                    case "Docente":
                        mainForm = new frmMain(per);
                        mainForm.ShowDialog();
                        break;

                }
            }

            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Limpiar();
            }

        }


        private void lnkRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonasDesktop pNueva = new PersonasDesktop(ApplicationForm.ModoForm.Alta, false);
            pNueva.ShowDialog();
        }

        #endregion

        #region Eventos
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        #endregion

    }
}

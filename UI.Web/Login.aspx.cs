using System;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {

        private Persona Existe(string user, string pass)
        {
            Persona per;
            PersonaLogic pl = new PersonaLogic();
            per = pl.GetByUser(user, pass);
            return per;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.CleanForm();
        }

        private void CleanForm()
        {
            this.usuarioTextBox.Text = string.Empty;
            this.claveTextBox.Text = string.Empty;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Persona per;
            per = Existe(this.usuarioTextBox.Text, this.claveTextBox.Text);

            if(per != null)
            {
                Session["persona"] = per;
                Response.Redirect("/PaginaPrincipal.aspx");
            }

            else
            {
                lblIngresoIncorrecto.Visible = true;
            }
        }
    }
}